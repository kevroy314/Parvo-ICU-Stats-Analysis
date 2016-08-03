#region Imports

using System;
using System.Drawing;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

#endregion

namespace ParvoICUStatsAnalyser
{
    internal class AnimalRecord
    {
        //149 Variables
        //95 Arrays
        //54 Scalars
        //1 Image
        //1 Image Array
        //20 DateTime Arrays
        //5 DateTimes
        //5 bools
        //3 int Arrays
        //1 double
        //42 strings
        //71 string Arrays
        //Title

        public string ReportTitle { get; set; }

        //Animal Subsection

        public string ANum { get; set; }

        public DateTime DatePrinted { get; set; }

        public Image Logo { get; set; }

        //Animal Details Subsection

        public string ARN { get; set; }

        public string Name { get; set; }

        public string AnimalSpecies { get; set; }

        public string AnimalGender { get; set; }

        public AgeRangeWhenCollectedTypes AgeRangeWhenCollected { get; set; }

        public string AnimalType { get; set; }

        public string AnimalSubType { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public double WeightInLbs { get; set; }

        public string AgeAtReportPrint { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Spayed { get; set; }

        public bool Declawed { get; set; }

        public string Bitten { get; set; }

        //Group Membership Subsection

        public string[] GroupNumbers { get; set; }

        public string[] GroupTypes { get; set; }

        public string[] GroupSubTypes { get; set; }

        public int[] GroupNumInGroup { get; set; }

        public DateTime[] GroupFormedDateTime { get; set; }

        public DateTime[] GroupCreatedDateTime { get; set; }

        public string[] GroupCreateBy { get; set; }

        public string[] GroupComments { get; set; }

        //Animal Point In Time Subsection

        public DateTime[] ApotDate { get; set; }

        public string[] ApotSource { get; set; }

        public string[] ApotSize { get; set; }

        public string[] ApotBcs { get; set; }

        public string[] ApotAnimalCondition { get; set; }

        public string[] ApotAsilomar { get; set; }

        public string[] ApotMedicalStatus { get; set; }

        public string[] ApotAgeGroup { get; set; }

        public string[] ApotTempStatus { get; set; }

        public string[] ApotWeight { get; set; }

        public string[] ApotBitten { get; set; }

        public string[] ApotDanger { get; set; }

        public string[] ApotSn { get; set; }

        public string[] ApotPulse { get; set; }

        public string[] ApotTemp { get; set; }

        public string[] ApotResp { get; set; }

        //Intake Subsection

        public DateTime IntakeDateTime { get; set; }

        public string IntakeType { get; set; }

        public string IntakeStatus { get; set; }

        public string IntakeLocation { get; set; }

        public string IntakePNum { get; set; }

        public string IntakeRecordOwner { get; set; }

        public string IntakeReason { get; set; }

        public string IntakeSource { get; set; }

        public string IntakeNotes { get; set; }

        //Outcome Subsection

        public DateTime OutcomeDateTime { get; set; }

        public string OutcomeStatus { get; set; }

        public string OutcomeType { get; set; }

        public string OutcomeLocation { get; set; }

        public string OutcomePNum { get; set; }

        public string OutcomeRecordOwner { get; set; }

        public string OutcomeRelease { get; set; }

        public DateTime OutcomeCreatedDate { get; set; }

        public string OutcomeJurisdiction { get; set; }

        public string OutcomeNotes { get; set; }

        //Ownership/Guardianship Subsection

        public string[] OwnerPNum { get; set; }

        public DateTime[] OwnerDateFrom { get; set; }

        public string[] OwnerName { get; set; }

        public string[] OwnerPhoneNum { get; set; }

        public string[] OwnerAddress { get; set; }

        public string[] OwnerCity { get; set; }

        //Stage Subsection

        public string[] Stage { get; set; }

        public DateTime[] StageDateTime { get; set; }

        public string[] StageReviewDate { get; set; }

        public string[] StageBy { get; set; }

        public string[] StageChangeReason { get; set; }

        //Location Subsection

        public string[] Location { get; set; }

        public string[] SubLocation { get; set; }

        public DateTime[] LocationDateTime { get; set; }

        public string[] LocationBy { get; set; }

        //Microchip Subsection

        public string[] MicrochipANum { get; set; }

        public string[] MicrochipProvider { get; set; }

        public DateTime[] MicrochipIssueDate { get; set; }

        //PetId Subsection

        public int[] PetIdNum { get; set; }

        public string[] PetIdType { get; set; }

        public DateTime[] PetIdIssueDate { get; set; }

        public DateTime[] PetIdExpireDate { get; set; }

        public string[] PetIdIssuerPhoneNum { get; set; }

        //Medical Summary Subsection

        public string[] MedRecordNumber { get; set; }

        public string[] MedRecordType { get; set; }

        public string[] MedRecordSubtype { get; set; }

        public string[] MedRecordMedStatus { get; set; }

        public string[] MedRecordTemperamentStatus { get; set; }

        public DateTime[] MedRecordDateTime { get; set; }

        public DateTime[] MedRecordReviewDate { get; set; }

        public string[] MedRecordNotes { get; set; }

        //Tests Subsection

        public string[] TestType { get; set; }

        public string[] TestForCondition { get; set; }

        public string[] TestResult { get; set; }

        public DateTime[] TestDateTime { get; set; }

        public DateTime[] TestResultDateTime { get; set; }

        public DateTime[] TestReTestDate { get; set; }

        public string[] TestRecordNum { get; set; }

        //Vaccinations Subsection

        public string[] VaccinationName { get; set; }

        public string[] VaccinationType { get; set; }

        public DateTime[] VaccinationDateTime { get; set; }

        public DateTime[] VaccinationReVaccDateTime { get; set; }

        public int[] VaccinationPetId { get; set; }

        public string[] VaccinationPetIdType { get; set; }

        public string[] VaccinationRecordNum { get; set; }

        //Treatments Subsection

        public string[] TreatmentName { get; set; }

        public string[] TreatmentType { get; set; }

        public string[] TreatmentDose { get; set; }

        public string[] TreatmentFor { get; set; }

        public DateTime[] TreatmentDateTime { get; set; }

        public DateTime[] TreatmentReviewDate { get; set; }

        public string[] TreatmentRecordNum { get; set; }

        //Memo Subsection

        public string[] MemoType { get; set; }

        public string[] MemoSubType { get; set; }

        public DateTime[] MemoDateTime { get; set; }

        public string[] MemoComments { get; set; }

        public string[] MemoBy { get; set; }

        public DateTime[] MemoReviewDate { get; set; }

        //Animal Profile Subsection

        public bool FeaturedPet { get; set; }

        public bool SpecialNeeds { get; set; }

        public double AdoptionPrice { get; set; }

        public string Housetrained { get; set; }

        public string HousetrainedComments { get; set; }

        public bool ServiceAnimal { get; set; }

        public string SpecialNeedsComments { get; set; }

        public string Veterinarian { get; set; }

        public string Allergies { get; set; }

        public string Medications { get; set; }

        public string SpecificKnownCommands { get; set; }

        public string AnimalProfileComments { get; set; }

        //Animals Subsection

        public string[] AnimalsQty { get; set; }

        public string[] AnimalsType { get; set; }

        public string[] AnimalsLivedWith { get; set; }

        public string[] AnimalsInteractedWith { get; set; }

        public string[] AnimalsTestedWith { get; set; }

        public string[] AnimalsDoNotPlace { get; set; }

        //People Subsection

        public string[] PeopleQty { get; set; }

        public string[] PeopleAgeGroups { get; set; }

        public string[] PeopleLivedWith { get; set; }

        public string[] PeopleInteractedWith { get; set; }

        public string[] PeopleTestedWith { get; set; }

        public string[] PeopleDoNotPlace { get; set; }

        //Activity Subsection

        public string EnjoyActivityLevel { get; set; }

        public string ImAfraidOfVocalizationLevel { get; set; }

        public string PeopleDescribeMeAsOffLeash { get; set; }

        public string TrainingHistory { get; set; }

        //Images Subsection

        public Image[] Images { get; set; }

        //URL Subsection

        public string FetchUrl { get; set; }

        //Custom Subsection

        public bool DiedOfParvo { get; set; }

        public bool Adopted { get; set; }

        public DateTime ParvoICUDischargeDateTime { get; set; }

        public TimeSpan TimeInParvoICU { get; set; }
        //Parser

        public static AnimalRecord HtmlDocumentToAnimalRecord(HtmlAgilityPack.HtmlDocument d)
        {
            // ReSharper disable UseObjectOrCollectionInitializer
            AnimalRecord r = new AnimalRecord();
            // ReSharper restore UseObjectOrCollectionInitializer

            try
            {
                // ReSharper disable InconsistentNaming
                // ReSharper disable UnusedVariable
                char[] _s = new[] {' '};
                char[] _colon = new[] {':'};
                char[] _comma = new[] {','};
                char[] _comma_s = new[] {',', ' '};
                // ReSharper restore UnusedVariable
                // ReSharper restore InconsistentNaming

                //Title
                r.ReportTitle = d.DocumentNode.SelectSingleNode("//head/title").InnerText.Trim();
                //Animal Subsection
                r.ANum = d.GetElementbyId("cphWorkArea_lblAnimalNumber").InnerText.Replace("Animal:", "").Trim();
                r.DatePrinted =
                    DateTime.Parse(d.GetElementbyId("cphWorkArea_lblPrintStamp").InnerText.Replace("Printed:", ""));
                //r.Logo
                //Animal Details Subsection
                r.ARN = d.GetElementbyId("cphWorkArea_lblARN").InnerText.Trim();
                r.Name = d.GetElementbyId("cphWorkArea_lblName").InnerText.Trim();
                r.AnimalSpecies = d.GetElementbyId("cphWorkArea_lblSpecies").InnerText.Trim();
                string[] description = d.GetElementbyId("cphWorkArea_lblLine1").InnerText.Split(_comma);
                r.AnimalType = description[0].Trim();
                r.AnimalSubType = description.Length >= 5 ? description[1].Trim() : "No Subtype Listed";
                r.Color = description[description.Length - 3].Trim();
                r.Size = description[description.Length - 2].Trim();
                try
                {
                    r.WeightInLbs =
                        double.Parse(Regex.Match(description[description.Length - 1].Trim(), @"\d+\.?\d*").Value);
                }
                catch (Exception)
                {
                    r.WeightInLbs = -1;
                }
                r.AnimalGender = d.GetElementbyId("cphWorkArea_lblGender").InnerText.Trim();
                r.AgeRangeWhenCollected = ParseAgeRangeWhenCollected(d.GetElementbyId("cphWorkArea_lblAgeGroup").InnerText.Trim());

                var reportAgeAndSpayedElement = d.GetElementbyId("cphWorkArea_lblLine2");
                if (reportAgeAndSpayedElement.ChildNodes.Count > 2) //Normal Case
                {
                    r.AgeAtReportPrint = reportAgeAndSpayedElement.ChildNodes[0].InnerText.Trim();
                    r.Spayed = d.GetElementbyId("cphWorkArea_lblLine2").ChildNodes[4].InnerText.Trim().ToLower() ==
                               "yes";
                    r.DateOfBirth = DateTime.Parse(d.GetElementbyId("cphWorkArea_lblLine2").ChildNodes[2].InnerText.Trim());
                }
                else
                {
                    r.AgeAtReportPrint = "Unknown";
                    r.Spayed = d.GetElementbyId("cphWorkArea_lblLine2").ChildNodes[1].InnerText.Trim().ToLower() ==
                               "yes";
                    r.DateOfBirth = DateTime.MinValue;
                }
                
                //?
                r.Declawed = d.GetElementbyId("cphWorkArea_lblLine3").ChildNodes[1].InnerText.Trim().ToLower() != "none";
                r.Bitten = d.GetElementbyId("cphWorkArea_lblLine4").ChildNodes[1].InnerText.Trim();
                var area = d.GetElementbyId("cphWorkArea_dgLocation").InnerHtml;
                var split0 = area.Split(new[] {"APA!! Parvo-Dog"}, StringSplitOptions.None);
                var split1 = split0[2].Split(new[] {"<td>", "</td>"}, StringSplitOptions.RemoveEmptyEntries);
                r.IntakeDateTime = DateTime.Parse(split1[0]);

                r.OutcomeType = d.GetElementbyId("cphWorkArea_RepeaterOutcome_hlkOutcomeType_0").InnerText;
                r.DiedOfParvo = r.OutcomeType == "Died" &&
                                d.GetElementbyId("cphWorkArea_RepeaterOutcome_txOutcomeSubType_0").InnerText ==
                                "Parvo Virus";

                r.Adopted = r.OutcomeType == "Adoption";

                var timeInWardArea = d.GetElementbyId("cphWorkArea_dgLocation");
                var timeInWardString = "";
                for(int i = 0; i < timeInWardArea.ChildNodes.Count;i++)
                    if (timeInWardArea.ChildNodes[i].InnerText.Contains("APA!! Parvo-Dog"))
                    {
                        timeInWardString = timeInWardArea.ChildNodes[i - 1].ChildNodes[3].InnerText;
                        break;
                    }

                r.ParvoICUDischargeDateTime = DateTime.Parse(timeInWardString);
                r.TimeInParvoICU = r.ParvoICUDischargeDateTime.Subtract(r.IntakeDateTime);
            }
            catch (Exception)
            {
                errCount++;
                Console.WriteLine("Error A#=" + r.ANum + " this is error " + errCount);
                return null;
            }

            return r;
        }

        public static int errCount = 0;
        public enum AgeRangeWhenCollectedTypes
        {
            ZeroToEightWeeks,
            TwoToFourMonths,
            FourToSixMonths,
            SixToEightMonths,
            EightToTenMonths,
            TenToTwelveMonths,
            AdultOneToSixYears,
            SeniorGreaterThanSixYears,
            Undefined
        };

        public static AgeRangeWhenCollectedTypes ParseAgeRangeWhenCollected(string input)
        {
            switch (input)
            {
                case "0-8wks":
                    return AgeRangeWhenCollectedTypes.ZeroToEightWeeks;
                case "2-4 months":
                    return AgeRangeWhenCollectedTypes.TwoToFourMonths;
                case "4-6 months":
                    return AgeRangeWhenCollectedTypes.FourToSixMonths;
                case "6-8 months":
                    return AgeRangeWhenCollectedTypes.SixToEightMonths;
                case "8-10 months":
                    return AgeRangeWhenCollectedTypes.EightToTenMonths;
                case "10-12 months":
                    return AgeRangeWhenCollectedTypes.TenToTwelveMonths;
                case "Adult 1yr-6yr":
                    return AgeRangeWhenCollectedTypes.AdultOneToSixYears;
                case "Senior >6yr":
                    return AgeRangeWhenCollectedTypes.SeniorGreaterThanSixYears;
            }

            return AgeRangeWhenCollectedTypes.Undefined;
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}