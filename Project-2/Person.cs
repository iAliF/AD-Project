using System;

namespace Project_2
{
    public class Person : IComparable
    {
        public readonly int Age;
        private char _skillLevel;

        public Person(int age, char skillLevel)
        {
            Age = age;
            SkillLevel = skillLevel;
        }

        public char SkillLevel
        {
            get => _skillLevel;
            set
            {
                if (value < 'A' || value > 'F')
                    throw new ArgumentOutOfRangeException(nameof(SkillLevel));

                _skillLevel = value;
            }
        }

        public int CompareTo(object other)
        {
            if (other is Person p)
            {
                if (Age != p.Age)
                    return p.Age.CompareTo(Age);

                // Higher skill level
                return SkillLevel.CompareTo(p.SkillLevel);
            }

            return 0;
        }

        public override string ToString()
        {
            return $"Age: {Age} / Skill: {SkillLevel}";
        }
    }
}