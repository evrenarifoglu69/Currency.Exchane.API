using Currency.Exchange.Test.Entities;
using System;

namespace Currency.Exchange.Test.Fixture
{
    public class ContextFixture : IDisposable
    {
        public TestDbContextMock testDbContextMock;

        public ContextFixture()
        {
            testDbContextMock = new TestDbContextMock();
        }

        // https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063?view=vs-2019
        #region ImplementIDisposableCorrectly
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~ContextFixture()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (testDbContextMock != null)
                {
                    testDbContextMock.Dispose();
                    testDbContextMock = null;
                }
            }
        }
        #endregion
    }
}
