using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GaisAutomation;

namespace GaisTests
{
    [TestClass]
    public class LoginTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Intialize();
        }

        [TestMethod]
        public void CreateAccountLogInAndFillInSurvey()
        {
            // Open Log In page
            LoginPage.GoTo();

            // Click on "Create Account" link to open the respective page
            CreateAccountPage.GoTo();

            // Fill in "Create Accont" form and click on "Create Profile" button
            CreateAccountPage.CreateNewAccount();

            // Verify that welcome text on "Welcome" page is shown
            Assert.AreEqual("VelkommenHvad vil du gerne?", WelcomePage.WelcomeText);

            // Click on "Workload" image to open "Workload" page
            WorkloadPage.GoTo();
            Assert.AreEqual("Velkommen. I det følgende kan du tage en måling af din arbejdslyst. Dine besvarelser er anonyme og behandles fortroligt.", WorkloadPage.SubtitleText);

            // Open first slide on "Workload" page
            WorkloadPage.FirstSlide.GoTo();
            Assert.AreEqual("Arbejdslyst kommer ikke af sig selv.Ud fra dine svar, giver GAIS dig et overblik over din arbejdslyst– og hjælp til udvikling.", WorkloadPage.FirstSlide.SubtitleText);

            // Open second slide on "Workload" page
            WorkloadPage.SecondSlide.GoTo();
            Assert.AreEqual("Kun du kan se dine svar. Dine svar vil blive samlet i din personlige rapport- men ingen kan se, hvad du har svaret.", WorkloadPage.SecondSlide.SubtitleText);

            // Open third slide on "Workload" page
            WorkloadPage.ThirdSlide.GoTo();
            Assert.AreEqual("GAIS kortlægger din arbejdslyst ud fra syv faktorer: Mening, Mestring, Ledelse, Balance, Resultater, Kolleger og Medbestemmelse.", WorkloadPage.ThirdSlide.SubtitleText);

            // Open fourth slide on "Workload" page
            WorkloadPage.FourthSlide.GoTo();
            Assert.AreEqual("Efter testen får du din rapport. Baseret på dine svar giver GAIS dig inspiration og værktøjer til at udvikle din arbejdslyst.", WorkloadPage.FourthSlide.SubtitleText);

            // Open fifth slide on "Workload" page
            WorkloadPage.FifthSlide.GoTo();
            WorkloadPage.FifthSlide.FillInForm();

            // Open sixth slide on "Workload" page
            WorkloadPage.SixthSlide.GoTo();
            Assert.AreEqual("timer9 minutterfavorite_borderSvar ærligtlock_outline100% anonymt", WorkloadPage.SixthSlide.SubtitleText);

            // Open "Survey" page
            SurveyPage.GoTo();

            // Fill in survey
            SurveyPage.FillInSurvey();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
