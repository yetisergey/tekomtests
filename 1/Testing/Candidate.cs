namespace Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Candidate
    {
        public string name;
        public uint weight;
        public uint growth;
        public uint age;
        public double eye;
        public List<string> habitsAndDiseases = new List<string>();
        public List<Trouble> troubles = new List<Trouble>();

        public Candidate(string _name, string _weight, string _growth, string _age, string _eye, string _habitsAndDiseases)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(_name) || string.IsNullOrWhiteSpace(_name))
            {
                errors.Add("Имя не должно быть пустым");
            }
            else
            {
                name = _name;
            }

            if (!uint.TryParse(_weight, out weight))
            {
                errors.Add("Вес в кг должен быть больше 0 и целым числом");
            }

            if (!uint.TryParse(_growth, out growth))
            {
                errors.Add("Рост в см должен быть больше 0 и целым числом");
            }

            if (!uint.TryParse(_age, out age))
            {
                errors.Add("Возраст должен быть больше 0 и целым числом");
            }

            if (!double.TryParse(_eye, out eye))
            {
                errors.Add("Зрение должно дробным числом");
            }

            if (eye > 1 && eye < 0)
            {
                errors.Add("Зрение должно быть от 0 до 1");
            }

            var _habitsAndDiseasesList = _habitsAndDiseases.Split(' ').ToList();
            _habitsAndDiseasesList.RemoveAll(u => u == string.Empty);
            _habitsAndDiseasesList.ToList().ForEach(u =>
            {
                habitsAndDiseases.Add(u);
            });

            if (errors.Count > 0)
            {
                throw new Exception(string.Join(Environment.NewLine, errors));
            }
        }
    }
}