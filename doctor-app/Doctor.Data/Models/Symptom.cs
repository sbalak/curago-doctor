﻿namespace Doctor.Data
{
    public class Symptom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorrespondingRole { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
}
