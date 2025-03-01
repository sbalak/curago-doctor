﻿using Doctor.Data;

namespace Doctor.Infrastructure
{
    public interface IStaffService
    {
        Task<Staff?> Create(string firstName, string lastName, string phone, int experience, string postCode, string registerInterest, int specialityId);
    }
}
