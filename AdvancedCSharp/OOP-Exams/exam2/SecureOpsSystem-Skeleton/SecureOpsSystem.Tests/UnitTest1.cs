using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SecureOpsSystem.Tests
{
    [TestFixture]
    public class SecureHubTests
    {
        private const string TestName = "TestName";
        private const string TestCategory = "TestCategory";
        private const double TestEffectiveness = 1;

        [Test]
        public void Test_Constructor()
        {
            SecureHub secureHub = new(10);

            Assert.AreEqual(10, secureHub.Capacity);
            Assert.AreEqual(0, secureHub.Tools.Count);
        }

        [TestCase(0), TestCase(-1)]
        public void Test_Capacity_ShouldBePositive_ArgumentException(int capacity)
        {
            SecureHub secureHub;
            Assert.Throws<ArgumentException>(() => secureHub = new(capacity));
        }

        [Test]
        public void Test_AddTool_SuccessfullyAdded_Message()
        {
            SecureHub secureHub = new(1);

            SecurityTool tool = new(TestName, TestCategory, TestEffectiveness);

            Assert.AreEqual($"Security Tool {tool.Name} added successfully.", secureHub.AddTool(tool));
            Assert.AreEqual(1, secureHub.Tools.Count);
        }

        [Test]
        public void Test_AddTool_SameNameCheck_Message()
        {
            SecureHub secureHub = new(2);

            SecurityTool tool = new(TestName, TestCategory, TestEffectiveness);
            secureHub.AddTool(tool);

            Assert.AreEqual($"Security Tool {tool.Name} already exists in the hub.", secureHub.AddTool(tool));
            Assert.AreEqual(1, secureHub.Tools.Count);
        }

        [Test]
        public void Test_AddTool_ExceedingCapacity_Message()
        {
            SecureHub secureHub = new(1);

            SecurityTool tool = new(TestName, TestCategory, TestEffectiveness);
            secureHub.AddTool(tool);

            SecurityTool tool2 = new(TestName + "1", TestCategory, TestEffectiveness);
            Assert.AreEqual($"Secure Hub is at full capacity.", secureHub.AddTool(tool2));
            Assert.AreEqual(1, secureHub.Tools.Count);
        }

        [Test]
        public void Test_RemoveTool_Successful()
        {
            SecureHub secureHub = new(2);

            SecurityTool tool = new(TestName, TestCategory, TestEffectiveness);
            secureHub.AddTool(tool);

            Assert.AreEqual(true, secureHub.RemoveTool(tool));
            Assert.AreEqual(0, secureHub.Tools.Count);
        }

        [Test]
        public void Test_RemoveTool_Unsuccessful()
        {
            SecureHub secureHub = new(2);

            SecurityTool tool = new(TestName, TestCategory, TestEffectiveness);
            SecurityTool notTheSameTool = new(TestName + "1", TestCategory, TestEffectiveness);
            secureHub.AddTool(tool);

            Assert.AreEqual(false, secureHub.RemoveTool(notTheSameTool));
            Assert.AreEqual(1, secureHub.Tools.Count);
        }

        [Test]
        public void Test_DeployTool()
        {
            SecureHub secureHub = new(1);

            SecurityTool tool = new(TestName, TestCategory, TestEffectiveness);
            secureHub.AddTool(tool);
            var deployedTool = secureHub.DeployTool(TestName);
            Assert.AreEqual(tool.Name, deployedTool.Name);
            Assert.AreEqual(tool.Category, deployedTool.Category);
            Assert.AreEqual(tool.Effectiveness, deployedTool.Effectiveness);
            //Assert.AreSame(tool, secureHub.DeployTool(TestName));
            Assert.AreEqual(0, secureHub.Tools.Count);
        }
        [Test]
        public void Test_DeployTool_NullCase()
        {
            SecureHub secureHub = new(1);

            SecurityTool tool = new(TestName, TestCategory, TestEffectiveness);
            secureHub.AddTool(tool);

            Assert.AreEqual(null, secureHub.DeployTool("NotRealName"));
            Assert.AreEqual(1, secureHub.Tools.Count);
        }

        [Test]
        public void Test_SystemReport()
        {
            SecurityTool securityTool = new(TestName, TestCategory, TestEffectiveness);
            SecurityTool securityTool1 = new(TestName + "1", TestCategory, TestEffectiveness);

            SecureHub secureHub = new(2);
            secureHub.AddTool(securityTool);
            secureHub.AddTool(securityTool1);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Secure Hub Report:");
            sb.AppendLine($"Available Tools: 2");
            sb.AppendLine(securityTool.ToString());
            sb.AppendLine(securityTool1.ToString());

            string report = secureHub.ToString();

            Assert.AreEqual(sb.ToString().TrimEnd(), secureHub.SystemReport());
        }
    }
}
