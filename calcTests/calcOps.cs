using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using calc;


namespace calcTests
{
    [TestClass]
    public class calcOps
    {
        [TestMethod]
        public void AdditionTest()
        {
            AddIt testAdd = new AddIt();
            ArrayList myNums = new ArrayList();
            myNums.Add(5);
            myNums.Add(5);
            int answer = testAdd.Addition(myNums);
            Assert.AreEqual(answer, 10);
        }

        [TestMethod]
        public void SubtractionTest()
        {
            SubtractIt testSubtract = new SubtractIt();
            ArrayList myNums = new ArrayList();
            myNums.Add(5);
            myNums.Add(5);
            int answer = testSubtract.Subtraction(myNums);
            Assert.AreEqual(answer, 0);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            MultiplyIt testMulti = new MultiplyIt();
            ArrayList myNums = new ArrayList();
            myNums.Add(5);
            myNums.Add(5);
            int answer = testMulti.Multiplication(myNums);
            Assert.AreEqual(answer, 25);
        }

        [TestMethod]
        public void DivisionTest()
        {
            DivideIt testDiv = new DivideIt();
            ArrayList myNums = new ArrayList();
            myNums.Add(5);
            myNums.Add(5);
            int answer = testDiv.Division(myNums);
            Assert.AreEqual(answer, 1);
        }

        [TestMethod]
        public void ModulusTest()
        {
            ModIt testMod = new ModIt();
            ArrayList myNums = new ArrayList();
            myNums.Add(5);
            myNums.Add(4);
            int answer = testMod.Modulation(myNums);
            Assert.AreEqual(answer, 1);
        }

        [TestMethod]
        public void extractsNumsTest()
        {
            string input = "3 + 4";
            RegexUtil processor = new RegexUtil();
            ArrayList answer = processor.ExtractNums(input);
            ArrayList expected = new ArrayList();
            expected.Add(3);
            expected.Add(4);
            CollectionAssert.AreEqual(expected, answer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void doesNotTakeBadInputWithTwoOps()
        {
            string input = "3 + %";
            RegexUtil processor = new RegexUtil();
            ArrayList answer = processor.ExtractNums(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void doesNotTakeBadInput()
        {
            string input = "3 +";
            RegexUtil processor = new RegexUtil();
            ArrayList answer = processor.ExtractNums(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoesNotTakeBadInput2()
        {
            string input = "+ 24 5";
            RegexUtil processor = new RegexUtil();
            ArrayList answer = processor.ExtractNums(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoesNotTakeNoOpPresent()
        {
            string input = "24";
            RegexUtil process = new RegexUtil();
            ArrayList answer = process.ExtractNums(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoesNotTakeAlphabet()
        {
            string input = "abc + def";
            RegexUtil process = new RegexUtil();
            ArrayList answer = process.ExtractNums(input);
        }

        [TestMethod]
        public void ExtractsAddOperand()
        {
            string input = "3 + 4";
            RegexUtil adding = new RegexUtil();
            string answer = adding.ExtractsOp(input);
            string expected = "+";
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void ExtractsSubOperand()
        {
            string input = "10 - 2";
            RegexUtil subtracting = new RegexUtil();
            string answer = subtracting.ExtractsOp(input);
            string expected = "-";
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void ExtractsDivOperandTest()
        {
            string input = "10 / 2";
            RegexUtil dividing = new RegexUtil();
            string answer = dividing.ExtractsOp(input);
            string expected = "/";
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void ExtractsMultiOperand()
        {
            string input = "10 * 2";
            RegexUtil multiplying = new RegexUtil();
            string answer = multiplying.ExtractsOp(input);
            string expected = "*";
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void ExtractsModOperand()
        {
            string input = "10 % 2";
            RegexUtil modulusing = new RegexUtil();
            string answer = modulusing.ExtractsOp(input);
            string expected = "%";
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void QuitProcessed()
        {
            ValidInputs TestQuit = new ValidInputs();
            bool answer = TestQuit.BreakingLoop("quit");
            Assert.AreEqual(false, answer);
        }

        [TestMethod]
        public void ExitProcessed()
        {
            ValidInputs TestExit = new ValidInputs();
            bool answer = TestExit.BreakingLoop("exit");
            Assert.AreEqual(false, answer);
        }

        // valid input takes anything that isn't an exit
        // if it is an improper input, RegexUtil will handle this
        [TestMethod]
        public void ValidInputRec4Regex()
        {
            string input = "3 + 4";
            ValidInputs TestRegexPass = new ValidInputs();
            bool answer = TestRegexPass.BreakingLoop(input);
            Assert.AreEqual(true, answer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestingWithoutOp()
        {
            string input = "5";
            Calculator thisCalc = new Calculator();
            int AdditionAns = thisCalc.Calculate(input);
        }

        [TestMethod]
        public void TestingCalculatorAddition()
        {
            string input = "4 + 2";
            Calculator thisCalc = new Calculator();
            int AdditionAns = thisCalc.Calculate(input);
            Assert.AreEqual(6, AdditionAns);
        }

        [TestMethod]
        public void TestingCalculatorMulti()
        {
            string input = "4 * 2";
            Calculator thisCalc = new Calculator();
            int MultiplicationAns = thisCalc.Calculate(input);
            Assert.AreEqual(8, MultiplicationAns);
        }

        [TestMethod]
        public void TestingCalculatorDiv()
        {
            string input = "4 / 2";
            Calculator thisCalc = new Calculator();
            int DivisionAns = thisCalc.Calculate(input);
            Assert.AreEqual(2, DivisionAns);
        }

        [TestMethod]
        public void TestingCalculatorSub()
        {
            string input = "12 - 2";
            Calculator thisCalc = new Calculator();
            int SubtractionAns = thisCalc.Calculate(input);
            Assert.AreEqual(10, SubtractionAns);
        }

        [TestMethod]
        public void TestingCalculatorModulation()
        {
            string input = "11 % 2";
            Calculator thisCalc = new Calculator();
            int ModAns = thisCalc.Calculate(input);
            Assert.AreEqual(1, ModAns);
        }

        [TestMethod]
        public void CanSetCounterVal()
        {
            Counter testCount = new Counter();
            testCount.CountValue = testCount.Count + 1;
            Assert.AreEqual(1, testCount.CountValue);
        }

        [TestMethod]
        public void HoldsLastQ()
        {
            LastQnA.LastQ= "1 + 4";
            Assert.AreEqual("1 + 4", LastQnA.LastQ);
        }

        [TestMethod]
        public void HoldsLastAns()
        {
            LastQnA.LastAns = 5;
            Assert.AreEqual(5, LastQnA.LastAns);
        }

        [TestMethod]
        public void ConstantParsing()
        {
            ConstantParser TestConstantParser = new ConstantParser();
            bool results = TestConstantParser.ConstTest("t = 0");
            Assert.AreEqual(true, results);
        }

        [TestMethod]
        public void ConstantParsedDoesNotTakeBadInput()
        {
            // still not sure why this doesn't work.
            ConstantParser TestConstantParser = new ConstantParser();
            bool results = TestConstantParser.ConstTest("xy = 0");
            Assert.AreEqual(false, results);
        }

        [TestMethod]
        public void ConstantParsedDoesNotTakeBadInput2()
        {
            ConstantParser TestConstantParser = new ConstantParser();
            bool results = TestConstantParser.ConstTest("0 = x");
            Assert.AreEqual(false, results);
        }

        [TestMethod]
        public void CanHoldKeyValuePair()
        {
            Constants.AddKey2Dictionary("x", 3);
            Dictionary<string, int> answer = new Dictionary<string, int>();
            answer.Add("x", 3);
            CollectionAssert.AreEqual(answer, Constants.SessionConstants); 
        }

        [TestMethod]
        public void HoldsConstantVals()
        {
            // need a dictionary for storage
            // need a regex for the constant value, use to lower on input
        }
    }
}
