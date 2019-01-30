using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using UPH_Simulation_Model;

namespace UPH_Simulation_ViewModel
{
    public class ObservableViewModelCollection<TViewModel, TModel> : ObservableCollection<TViewModel> where TViewModel : INotifyPropertyChanged where TModel : INotifyPropertyChanged
    {
        private readonly TrulyObservableCollection<TModel> _source;
        private readonly Func<TModel, TViewModel> _viewModelFactory;
        private readonly Action<TModel, string> _viewModelConverter;

         public ObservableViewModelCollection(TrulyObservableCollection<TModel> source, Func<TModel, TViewModel> viewModelFactory, Action<TModel, string> viewModelConverter)
            : base(((IEnumerable<TModel>)source).Select(model => viewModelFactory(model)))
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (viewModelFactory == null)
                throw new ArgumentNullException("viewModelFactory");
            Contract.EndContractBlock();

            this._source = source;
            this._viewModelFactory = viewModelFactory;
            this._viewModelConverter = viewModelConverter;
            this._source.CollectionChanged += OnSourceCollectionChanged;
            this._source.ItemPropertyChanged += OnPropertyChanged;
        }

        protected virtual TViewModel CreateViewModel(TModel model)
        {
            return _viewModelFactory(model);
        }

        protected virtual void ConvertViewModel(TModel model, string propertyName)
        {
            _viewModelConverter(model, propertyName);
        }

        private void OnSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        this.Insert(e.NewStartingIndex + i, CreateViewModel((TModel)e.NewItems[i]));
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    if (e.OldItems.Count == 1)
                    {
                        this.Move(e.OldStartingIndex, e.NewStartingIndex);
                    }
                    else
                    {
                        List<TViewModel> items = this.Skip(e.OldStartingIndex).Take(e.OldItems.Count).ToList();
                        for (int i = 0; i < e.OldItems.Count; i++)
                            this.RemoveAt(e.OldStartingIndex);

                        for (int i = 0; i < items.Count; i++)
                            this.Insert(e.NewStartingIndex + i, items[i]);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                        this.RemoveAt(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    // remove
                    for (int i = 0; i < e.OldItems.Count; i++)
                        this.RemoveAt(e.OldStartingIndex);

                    // add
                    goto case NotifyCollectionChangedAction.Add;

                case NotifyCollectionChangedAction.Reset:
                    Clear();
                    if(e.NewItems != null)
                    {
                        for (int i = 0; i < e.NewItems.Count; i++)
                            this.Add(CreateViewModel((TModel)e.NewItems[i]));
                    }

                    break;

                default:
                    break;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ConvertViewModel((TModel)sender, e.PropertyName);
        }
    }
}
