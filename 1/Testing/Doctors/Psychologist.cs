namespace Testing.Doctors
{
    using System.Collections.Generic;
    public class Psychologist : Doctor
    {
        public Psychologist()
        {
            dictionaryOfTroubles =
                new List<Trouble>() {
                new Trouble() { field = FieldEnum.psychiatry,nameRus = "Алкоголизм",nameEng = "alcoholism" },
                new Trouble() { field = FieldEnum.psychiatry,nameRus = "Бессонница",nameEng = "insomnia" },
                new Trouble() { field = FieldEnum.psychiatry,nameRus = "Наркомания",nameEng = "narcomania" },
                new Trouble() { field = FieldEnum.psychiatry,nameRus = "Травмы",nameEng = "injury" },
                new Trouble() { field = FieldEnum.psychiatry,nameRus = "Курение",nameEng = "smoke" } };
        }
    }
}