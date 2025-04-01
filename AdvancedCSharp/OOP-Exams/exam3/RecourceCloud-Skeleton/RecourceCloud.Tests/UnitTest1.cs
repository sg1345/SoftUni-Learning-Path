using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_Constructor()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();

            Assert.AreEqual(0, departmentCloud.Tasks.Count);
            Assert.AreEqual(0, departmentCloud.Resources.Count);
        }

        [TestCase(0), TestCase(2), TestCase(4)]
        public void Test_LogTask_AllArgumentsRequired_ArgumentException(int length)
        {
            string[] args = new string[length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = $"argument {i}";
            }

            DepartmentCloud departmentCloud = new DepartmentCloud();

            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(args));
        }

        [Test]
        public void Test_LogTask_ValueIsNull_ArgumentException()
        {
            string[] args = new string[3];

            for (int i = 0; i < args.Length - 1; i++)
            {
                args[i] = $"argument {i}";
            }

            DepartmentCloud departmentCloud = new DepartmentCloud();

            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(args));
        }

        [Test]
        public void Test_LogTask_MessagesChecker()
        {
            string[] args = new string[3];

            args[0] = "1";
            for (int i = 1; i < args.Length; i++)
            {
                args[i] = $"argument {i}";
            }

            DepartmentCloud departmentCloud = new DepartmentCloud();

            Assert.AreEqual($"Task logged successfully.", departmentCloud.LogTask(args));

            Task task = new Task(int.Parse(args[0]), args[1], args[2]);
            Task testedTask = departmentCloud.Tasks.FirstOrDefault(t => t.ResourceName == task.ResourceName)!;

            Assert.AreEqual(task.ResourceName, testedTask.ResourceName);
            Assert.AreEqual(task.Label, testedTask.Label);
            Assert.AreEqual(task.Priority, testedTask.Priority);

            Assert.AreEqual($"{task.ResourceName} is already logged.", departmentCloud.LogTask(args));
        }

        [Test]
        public void Test_CreateResource()
        {
            string[] args = new string[3];

            args[0] = "2";
            for (int i = 1; i < args.Length; i++)
            {
                args[i] = $"argument {i}";
            }

            DepartmentCloud departmentCloud = new DepartmentCloud();

            Assert.AreEqual(false, departmentCloud.CreateResource());

            departmentCloud.LogTask(args);

            args[0] = "1";
            args[1] = "DifferentArgument 1";
            args[2] = "DifferentArgument 2";

            departmentCloud.LogTask(args);

            Assert.AreEqual(true, departmentCloud.CreateResource());

            Task currentTask = new Task(int.Parse(args[0]), args[1], args[2]);

            Resource currentResourse = new Resource(currentTask.ResourceName, currentTask.Label);
            Resource newlyAddedResource = departmentCloud.Resources.FirstOrDefault(x => x.Name == currentResourse.Name);

            Assert.AreEqual(currentResourse.Name, newlyAddedResource.Name);
            Assert.AreEqual(currentResourse.ResourceType, newlyAddedResource.ResourceType);

            Assert.AreEqual(null, departmentCloud.Tasks.FirstOrDefault(t => t.ResourceName == currentTask.ResourceName));
        }

        [Test]
        public void Test_TestResource()
        {
            string[] args = new string[3];

            args[0] = "2";
            for (int i = 1; i < args.Length; i++)
            {
                args[i] = $"argument {i}";
            }

            Resource resource = new(args[2], args[1]);

            DepartmentCloud departmentCloud = new DepartmentCloud();

            Assert.AreEqual(null, departmentCloud.TestResource(resource.Name));

            departmentCloud.LogTask(args);
            departmentCloud.CreateResource();

            args[0] = "1";
            args[1] = "DifferentArgument 1";
            args[2] = "DifferentArgument 2";

            departmentCloud.LogTask(args);
            departmentCloud.CreateResource();

            Resource testedResource = departmentCloud.TestResource(resource.Name);

            Assert.AreEqual(resource.Name, testedResource.Name);
            Assert.AreEqual(resource.ResourceType, testedResource.ResourceType);

            Assert.AreEqual(true,departmentCloud.Resources.FirstOrDefault(r=>r.Name == testedResource.Name).IsTested);
        }
    }
}