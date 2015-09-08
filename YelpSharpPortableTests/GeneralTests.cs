using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using YelpSharpPortable;
using YelpSharpPortable.Data;
using YelpSharpPortable.Data.Options;

namespace YelpSharpPortableTests
{
    /// <summary>
    /// General tests for the API.
    /// </summary>
    [TestClass]
    public class GeneralTests
    {
        //--------------------------------------------------------------------------
        //
        //	Variables
        //
        //--------------------------------------------------------------------------

        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        //--------------------------------------------------------------------------
        //
        //	Constructors
        //
        //--------------------------------------------------------------------------

        public GeneralTests()
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
        /// Basic search test to verify the API.
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            var y = new Yelp(Config.Options);
            var results = y.Search("coffee", "seattle, wa").Result;
            if (results.Error != null)
            {
                Assert.Fail(results.Error.Text);
            }
        }

        /// <summary>
        /// Test search with location and search term
        /// </summary>
        [TestMethod]
        public void VerifyGeneralOptions()
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
        /// Verify URL escaped characters do not cause search to fail
        /// </summary>
        [TestMethod]
        public void UrlEscapedCharacters()
        {
            var y = new Yelp(Config.Options);

            var searchOptions = new SearchOptions();
            searchOptions.GeneralOptions = new GeneralOptions()
            {
                Term = "coffee $&`:<>[]{}\"#%@/;=?\\^|~', tea"
                //term = "coffee $`:<>[]{}\"#%@/;=?\\^|~', tea"
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
        /// Verify URL escaped characters do not cause search to fail
        /// </summary>
        [TestMethod]
        public void VerifyTermWithEscapedCharacter()
        {
            var y = new Yelp(Config.Options);
            var searchOptions = new SearchOptions
            {
                GeneralOptions = new GeneralOptions
                {
                    Term = "Frimark Keller & Associates"
                },
                LocationOptions = new LocationOptions
                {
                    Location = "60173"
                }
            };

            var results = y.Search(searchOptions).Result;
            Assert.IsTrue(results.Businesses != null);
            Assert.IsTrue(results.Businesses.Count > 0);
        }

        /// <summary>
        /// test loading a business explicitely by name
        /// </summary>
        [TestMethod]
        public void BusinessTest()
        {
            var y = new Yelp(Config.Options);
            var results = y.GetBusiness("yelp-san-francisco").Result;
            Assert.IsTrue(results != null);
        }

        /// <summary>
        /// perform a search with multiple categories on the general options filter
        /// </summary>
        [TestMethod]
        public void MultipleCategories()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new YelpSharpPortable.Data.Options.SearchOptions()
            {
                GeneralOptions = new GeneralOptions() { CategoryFilter = "climbing,bowling" },
                LocationOptions = new LocationOptions()
                {
                    Location = "Seattle"
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.Businesses.Count > 0);
        }

        /// <summary>
        /// Verify the limit parameter works as expected.
        /// </summary>
        [TestMethod]
        public void LimitTest()
        {
            var y = new Yelp(Config.Options);
            var searchOptions = new SearchOptions()
            {
                GeneralOptions = new GeneralOptions()
                {
                    Term = "coffee",
                    Limit = 15,
                },
                LocationOptions = new LocationOptions()
                {
                    Location = "seattle, wa"
                }
            };

            var results = y.Search(searchOptions).Result;
            if (results.Error != null)
            {
                Assert.Fail(results.Error.Text);
            }
            if (results.Businesses.Count != 15)
            {
                Assert.Fail("Limit test returned {0} results instead of 15", results.Businesses.Count);
            }
        }

        [TestMethod]
        public async void SearchByPhoneTest()
        {
            var y = new Yelp(Config.Options);
            SearchResults results = y.SearchByPhone("4159083801").Result;
            Assert.IsNotNull(results);
            Assert.IsNotNull(results.Businesses);
            Assert.IsNotNull(results.Businesses.First());
            Assert.AreEqual<string>("yelp-san-francisco", results.Businesses.First().Id);
        }
    }
}
