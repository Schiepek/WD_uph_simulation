using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public class UphSimulation
    {
        private AssemblyLine assemblyLine;

        public UphAlgorithm Algorithm;

        private AssemblyLineInitiator initiator = new AssemblyLineInitiator();

        private AssemblyLineValidator validator = new AssemblyLineValidator();

        private bool algorithmIsReady;

        public UphSimulation(AssemblyLine assemblyLine)
        {
            this.assemblyLine = assemblyLine;
            this.Algorithm = new UphAlgorithm(assemblyLine);
            assemblyLine.Reset();
        }

        public void CalculateResult()
        {
            Reset();
            PrepareAlgorithm();
            Algorithm.Calculate();
            NotifyPositionChanges();
        }

        public void ProceedOneTimeStep()
        {
            if(!algorithmIsReady)
            {
                PrepareAlgorithm();
            }
            Algorithm.ProceedOneTimeStep();
            NotifyPositionChanges();
        }

        public void ProceedOneSecond()
        {
            if (!algorithmIsReady)
            {
                PrepareAlgorithm();
            }
            for (int i = 0; i < UphConfig.OneSecondInSteps ; i++)
            {
                Algorithm.ProceedOneTimeStep();
            }
            NotifyPositionChanges();
        }

        public void ProceedOneRound()
        {
            if (!algorithmIsReady)
            {
                PrepareAlgorithm();
            }
            int currentRound = Algorithm.Round;
            while(currentRound == Algorithm.Round)
            {
                Algorithm.ProceedOneTimeStep();
            }
            if (Algorithm.Round > 1)
            {
                Algorithm.CalculateResult();
            }            
            NotifyPositionChanges();
        }

        public void Reset()
        {
            assemblyLine.Reset();
            Algorithm.Reset();
            algorithmIsReady = false;
            NotifyPositionChanges();            
        }

        private void PrepareAlgorithm()
        {
            initiator.Execute(assemblyLine);
            validator.Validate(assemblyLine);
            algorithmIsReady = true;
        }

        private void NotifyPositionChanges()
        {
            foreach(Position position in assemblyLine.GetPositions())
            {
                position.NotifyPropertyChanged("State");
            }
        }


    }
}
