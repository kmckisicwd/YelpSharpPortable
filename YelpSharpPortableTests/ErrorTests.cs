using Microsoft.VisualStudio.TestTools.UnitTesting;
using YelpSharpPortable;
using YelpSharpPortable.Data.Options;

namespace YelpSharpPortableTests
{
    /// <summary>
    /// Tests focused on verifying errors.
    /// </summary>
    [TestClass]
    public class ErrorTests
    {
        //--------------------------------------------------------------------------
        //
        //	Variables
        //
        //--------------------------------------------------------------------------

        private TestContext _testContextInstance;

        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

        //--------------------------------------------------------------------------
        //
        //	Constructors
        //
        //--------------------------------------------------------------------------

        public ErrorTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //--------------------------------------------------------------------------
        //
        //	Test Methods
        //
        //--------------------------------------------------------------------------

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Verify UNAVAILABLE_FOR_LOCATION is returned in error.id
        /// </summary>
        [TestMethod]
        public void ErrorTest_UNAVAILABLE_FOR_LOCATION()
        {
            var y = new Yelp(Config.Options);

            var searchOptions = new SearchOptions()
            {
                LocationOptions = new CoordinateOptions()
                {
                    Latitude = 1,
                    Longitude = 1
                }
            };

            var results = y.Search(searchOptions).Result;
            Assert.IsTrue(results.Error != null);
            Assert.IsTrue(results.Error.Id == YelpSharpPortable.Data.ErrorId.UnavailableForLocation);
        }

        /// <summary>
        ///  Verify UNSPECIFIED_LOCATION is returned in error.id
        /// </summary>
        [TestMethod]
        public void ErrorTest_UNSPECIFIED_LOCATION()
        {            
            var y = new Yelp(Config.Options);

            var searchOptions = new SearchOptions();

            var results = y.Search(searchOptions).Result;
            Assert.IsTrue(results.Error != null);
            Assert.IsTrue(results.Error.Id == YelpSharpPortable.Data.ErrorId.UnspecifiedLocation);
        }

        [TestMethod]
        public void ErrorTest_UNAVAILABLE_BUSINESS()
        {
            var y = new Yelp(Config.Options);
            var business = y.GetBusiness("foo-bar").Result;

            Assert.IsNull(business);
        }
    }
}
