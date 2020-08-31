using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;
using HarryPotterV2.Utils;
using System;

namespace HarryPotterV2
{
    [TestFixture]
    public class Tests : Endpoints
    {
        

       [OneTimeSetUp]
        public void Setup()
        {
            ReportingUtil.InitializeExtentReport("harry");
        }

        [OneTimeTearDown]
        public void teardown()
        {
            ReportingUtil.extent.Flush();

           
        }

        [Test]
        public void GetAllCharacters()
        {
            ReportingUtil.test = ReportingUtil.extent.CreateTest("Get(/characters");
            ReportingUtil.test.Info("Getting all character from Harry Potter");
            try
            {
                IRestClient client = new RestClient(Endpoints.BASE_URL);
                IRestRequest request = new RestRequest("/characters").AddParameter("key", Endpoints.API_KEY);

                IRestResponse response = client.Get(request);

                string content = response.Content;
                IList<Character> characters = JsonConvert.DeserializeObject<IList<Character>>(content);

                Assert.AreEqual(195, characters.Count);
                


                ReportingUtil.test.Log(Status.Pass, "successfully asserted the payload");

            }
            catch(AssertionException e)
            {
                ReportingUtil.test.Log(Status.Fail, "Assertion Failed check getAllCharacters method");
            }
            
           
            
           


        }

        [Test]
        public void getSortingHat()
        {
            ReportingUtil.test = ReportingUtil.extent.CreateTest("Get(/sortingHat");
            ReportingUtil.test.Info("assigning to a Hogwarts house");

            try
            {
                IRestClient client = new RestClient(Endpoints.BASE_URL);
                IRestRequest request = new RestRequest("/sortingHat");

                IRestResponse response = client.Get(request);

                IList<string> houses = new List<string>();
                houses.Add("Gryffindor");
                houses.Add("Ravenclaw");
                houses.Add("Hufflepuff");
                houses.Add("Slytherin");

                Assert.IsTrue(houses.Contains(response.Content.ToString().Replace("\"","")));

                ReportingUtil.test.Log(Status.Pass, "Asserted the assigned house, it is "+response.Content.ToString());

            }catch(Exception e)
            {
                ReportingUtil.test.Log(Status.Fail, "Assertion Failed check getSortingHat method");
            }

        }
    }
}