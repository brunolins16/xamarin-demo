using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Demo.Shared.Test
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("Dado que iniciei a aplicação");

            app.EnterText(ap => ap.TextField(), "bruno");
            app.Screenshot("E entrei as informações do Bruno");

            app.Tap(ap => ap.Button());
            app.Screenshot("Então exibiu o alerta");
        }
    }
}

