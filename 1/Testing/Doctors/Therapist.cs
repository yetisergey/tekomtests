namespace Testing.Doctors
{
    using System.Collections.Generic;
    public class Therapist : Doctor
    {
        public Therapist()
        {
            dictionaryOfTroubles =
                new List<Trouble>() {
                new Trouble() {field = FieldEnum.therapy,nameRus="Насморк",nameEng="cold" },
                new Trouble() {field = FieldEnum.therapy,nameRus="Бронхит",nameEng="bronchitis" },
                new Trouble() {field = FieldEnum.therapy,nameRus="Вирусы",nameEng="virus" },
                new Trouble() {field = FieldEnum.therapy,nameRus="Аллергия",nameEng="allergy" },
                new Trouble() {field = FieldEnum.therapy,nameRus="Ангина",nameEng="quinsy" },
                new Trouble() {field = FieldEnum.therapy,nameRus="Бессонница",nameEng="insomnia" } };
        }
    }
}