using AutoMapper;
using Currency.Exchange.API.Controllers;
using Currency.Exchange.Services.Auth;
using Currency.Exchange.Test.Entities;
using System;

namespace Currency.Exchange.Test.Fixture
{
    public class ControllerFixture : IDisposable
    {

        private TestDbContextMock testDbContextMock { get; set; }
        private IAuthService authService { get; set; }
        private IMapper mapper { get; set; }

        public AuthController authController { get; private set; }

        public ControllerFixture()
        {
            #region Create mock/memory database

            testDbContextMock = new TestDbContextMock();

            
            #endregion

            #region Mapper settings with original profiles.


            //mapper = mappingConfig.CreateMapper();

            #endregion


            // Create Controller
            authController = new AuthController(authService);

        }

        #region ImplementIDisposableCorrectly
        /** https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063?view=vs-2019 */
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~ControllerFixture()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                testDbContextMock.Dispose();
                testDbContextMock = null;

                authController = null;
                mapper = null;

                authService = null;
            }
        }
        #endregion
    }
}
