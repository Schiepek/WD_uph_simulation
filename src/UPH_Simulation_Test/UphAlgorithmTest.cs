using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPH_Simulation_Model;

namespace UPH_Simulation_Test
{
    [TestClass]
    public class UphAlgorithmTest
    {
        private static readonly int SPECIFIC_POSITION = 46;

        private static readonly int NUMBER_OF_DIGITS = 2;

        private AssemblyLine assemblyLine;

        [TestInitialize]
        public void InitializePositions()
        {
            assemblyLine = new AssemblyLine("requirements_line", 11);


            AssemblyLineItem a = new AssemblyLineItem(1, "a");
            AssemblyLineItem ab = new AssemblyLineItem(2, "ab");
            AssemblyLineItem b = new AssemblyLineItem(3, "b");
            AssemblyLineItem bc = new AssemblyLineItem(4, "bc");
            AssemblyLineItem c = new AssemblyLineItem(5, "c");
            AssemblyLineItem cd = new AssemblyLineItem(6, "cd");
            AssemblyLineItem d = new AssemblyLineItem(7, "d");
            AssemblyLineItem da = new AssemblyLineItem(8, "de");

            assemblyLine.Add(a);
            assemblyLine.Add(ab);
            assemblyLine.Add(b);
            assemblyLine.Add(bc);
            assemblyLine.Add(c);
            assemblyLine.Add(cd);
            assemblyLine.Add(d);
            assemblyLine.Add(da);

            a.Add(new BufferZone(1, "aZ1", 2));
            a.Add(new TransferPosition(2, "aT1", 1));
            a.Add(new WorkZone(3, "aZ2", 4));
            a.Add(new TransferPosition(4, "aT2", 1));
            a.Add(new BufferZone(5, "aZ3", 2));

            ab.Add(new TransferPosition(1, "aT", 2));

            b.Add(new BufferZone(1, "bZ1", 2));
            b.Add(new TransferPosition(2, "bT1", 1));
            b.Add(new DualZone(3, "bZ2", 10, 2, "swage"));
            b.Add(new TransferPosition(4, "bT2", 1));
            b.Add(new BufferZone(5, "bZ3", 2));

            bc.Add(new TransferPosition(1, "bT", 2));           
            
            c.Add(new DualZone(1, "cZ1", 10, 2, "swage"));
            c.Add(new TransferPosition(2, "cT1", 1));
            c.Add(new BufferZone(3, "cZ2", 2));
            c.Add(new TransferPosition(4, "cT2", 1));
            c.Add(new DualZone(5, "cZ3", 10, 2, "swage"));

            cd.Add(new TransferPosition(1, "cT", 2));  
            
            d.Add(new WorkZone(1, "dZ1", 4));
            d.Add(new TransferPosition(2, "dT1", 1));
            d.Add(new WorkZone(3, "dZ2", 5));
            d.Add(new TransferPosition(4, "dT2", 1));
            d.Add(new BufferZone(5, "dZ3", 2));

            da.Add(new TransferPosition(1, "dT", 2));

            new AssemblyLineValidator().Validate(assemblyLine);
            new AssemblyLineInitiator().Execute(assemblyLine);

            UphConfig.NumberOfDigits = NUMBER_OF_DIGITS;
        }


        [TestMethod]
        public void TestSpecificPosition()
        {
            UphAlgorithm algorithm = new UphAlgorithm(assemblyLine);
            List<Unit> units = algorithm.Units.All();
            int numberOfRequiredLoops = Convert.ToInt32(SPECIFIC_POSITION / UphConfig.TimeStep);

            for (int i = 0; i < numberOfRequiredLoops; i++)
            {
                algorithm.ProceedOneTimeStep();
            }

            AssertUnit(units[0], 21, 1.0, PositionState.WORK);
            AssertUnit(units[1], 18, 2.0, PositionState.BUFFER);
            AssertUnit(units[2], 16, 1.0, PositionState.BUFFER);
            AssertUnit(units[3], 9, 10.0, PositionState.WORK);
            AssertUnit(units[4], 7, 9.0, PositionState.WAIT);
            AssertUnit(units[5], 5, 10.0, PositionState.WAIT);
            AssertUnit(units[6], 3, 10.0, PositionState.WAIT);
            AssertUnit(units[7], 1, 10.0, PositionState.WAIT);
        }

        private void AssertUnit(Unit unit, int positionNumber, double currentTime, PositionState state)
        {
            Assert.AreEqual(positionNumber, unit.CurrentPosition.GlobalNumber);
            Assert.AreEqual(currentTime, Math.Round(unit.CurrentPosition.Time.CurrentTime, 1));
            Assert.AreEqual(state, unit.CurrentPosition.State);
        }
    }
}
