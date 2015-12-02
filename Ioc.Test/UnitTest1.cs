using System;
using Hangfire;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Ioc.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IKernel _kernel;

        [TestInitialize]
        public void SetUp()
        {
            _kernel = new StandardKernel();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_ThrowsAnException_WhenKernelIsNull()
        {
            // ReSharper disable once UnusedVariable
            var activator = new NinjectJobActivator(null);
        }
        [TestMethod]
        public void Class_IsBasedOnJobActivator()
        {
            var activator = CreateActivator();
            Assert.IsInstanceOfType(activator, typeof(JobActivator));
        }

        [TestMethod]
        public void ActivateJob_CallsNinject()
        {
            _kernel.Bind<string>().ToConstant("called");
            var activator = CreateActivator();

            var result = activator.ActivateJob(typeof(string));

            Assert.AreEqual("called", result);
        }
        private NinjectJobActivator CreateActivator()
        {
            return new NinjectJobActivator(_kernel);
        }

        class Disposable : IDisposable
        {
            public bool Disposed { get; set; }

            public void Dispose()
            {
                Disposed = true;
            }
        }

    }
}
