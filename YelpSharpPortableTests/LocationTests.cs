using Microsoft.VisualStudio.TestTools.UnitTesting;
using YelpSharpPortable;
using YelpSharpPortable.Data.Options;

namespace YelpSharpPortableTests
{
    /// <summary>
    /// Tests focused on searching the API by location.
    /// </summary>
    [TestClass]
    public class LocationTests
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

        public LocationTests()
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
        /// Test search with location and search term
        /// </summary>
        [TestMethod]
        public void LocationBasic()
        {
            var y = new Yelp(Config.Options);

            var searchOptions = new SearchOptions();
            searchOptions.GeneralOptions = new GeneralOptions()
            {
                Term = "coffee"
            };

            searchOptions.LocationOptions = new LocationOptions()
            {
                Location = "seattle"
            };

            var results = y.Search(searchOptions).Result;
            Assert.IsTrue(results.Businesses != null);
            Assert.IsTrue(results.Businesses.Count > 0);
        }

        /// <summary>
        /// check using location options with coordinates
        /// </summary>
        [TestMethod]
        public void LocationWithCoordinates()
        {
            var yelp = new Yelp(Config.Options);

            var searchOptions = new YelpSharpPortable.Data.Options.SearchOptions()
            {
                GeneralOptions = new GeneralOptions() { Term = "food" },
                LocationOptions = new LocationOptions()
                {
                    Location = "bellevue",
                    Coordinates = new CoordinateOptions()
                    {
                        Latitude = 37.788022,
                        Longitude = -122.399797
                    }
                }
            };

            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.Businesses.Count > 0);
        }

        /// <summary>
        /// check using location options with coordinates
        /// </summary>
        [TestMethod]
        public void LocationByCoordinates()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new YelpSharpPortable.Data.Options.SearchOptions()
            {
                LocationOptions = new BoundOptions()
                {
                    SwLatitude = 37.9,
                    SwLongitude = -122.5,
                    NeLatitude = 37.788022,
                    NeLongitude = -122.399797
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.Businesses.Count > 0);
        }

        /// <summary>
        /// check using bounds location options
        /// </summary>
        [TestMethod]
        public void LocationByBounds()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new YelpSharpPortable.Data.Options.SearchOptions()
            {
                LocationOptions = new CoordinateOptions()
                {
                    Latitude = 37.788022,
                    Longitude = -122.399797
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.Businesses.Count > 0);
        }

        /// <summary>
        /// Verify searching by coordinates with a radius filter.
        /// </summary>
        [TestMethod]
        public void VerifyCoordinatesWithRadius()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new YelpSharpPortable.Data.Options.SearchOptions()
            {
                GeneralOptions = new GeneralOptions() {
                    RadiusFilter = 3000
                },
                LocationOptions = new CoordinateOptions()
                {
                    Latitude = 47.603525,
                    Longitude = -122.329580
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.Businesses.Count > 0);
        }

        /// <summary>
        /// check using location options with coordinates
        /// </summary>
        [TestMethod]
        public void LocationWithRadius()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new YelpSharpPortable.Data.Options.SearchOptions()
            {
                GeneralOptions = new GeneralOptions() { Term = "food", RadiusFilter = 5 },
                LocationOptions = new LocationOptions()
                {
                    Location = "bellevue"
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.Businesses.Count > 0);
        }

        /// <summary>
        /// search for a business, and ensure the lat & long are available
        /// </summary>
        [TestMethod]
        public void VerifyLocationInResult()
        {
            var y = new Yelp(Config.Options);
            var results = y.Search("coffee", "seattle, wa").Result;
            if (results.Error != null)
            {
                Assert.Fail(results.Error.Text);
            }
            var bus = results.Businesses[0];
            if (bus.Location.Coordinate == null)
                Assert.Fail("No coordinate found on location for business");
        }
    }
}
