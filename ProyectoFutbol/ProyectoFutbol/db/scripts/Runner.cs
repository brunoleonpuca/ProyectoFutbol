namespace ProyectoFutbol.db.scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    public class Runner
    {
        private readonly DataAccess da = new DataAccess();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

        }

        [Test]
        public void ResetLeaguesData()
        {
            Assert.IsTrue(da.ResetLeaguesTable());
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }

    }
}
