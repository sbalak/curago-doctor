﻿namespace Doctor.Data
{
    public class Speciality
    {
        public int Id { get; set; }
        public bool IsPrimary { get; set; }
        public string Name { get; set; }
        public string CorrespondingRole { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
}
