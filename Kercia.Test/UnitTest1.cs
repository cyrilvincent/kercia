using Kercia.Model;
using Kercia.Model.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestYield()
        {
            YieldExample y = new YieldExample();
            var res = y.FilterByLambda(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, x => x % 2 == 0);
            res = y.FilterByLambda(res, x => x % 3 == 0);
            foreach (int i in res)
            {
                Console.WriteLine(i);
            }
            Assert.Pass();

        }

        [Test]
        public void TestIQueryable()
        {
            IEnumerable<int> ie = null;
            IQueryable<int> iq = null;
            IQueryable<int> iq2 = iq.Where(x => x % 2 == 0);
            //iq2.Where()
        }

        [Test]
        public void TestAdd()
        {
            AV_DASHBOARDContext context = new AV_DASHBOARDContext();
            Personne p = context.Personne.Find(1);
            Evenement e = context.Evenement.First();
            p.Evenements.Add(e);
            //e.Personne = p
            e.Personne.Id = p.Id;
            context.ChangeTracker;

        }
}