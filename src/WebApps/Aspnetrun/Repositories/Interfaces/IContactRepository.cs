﻿using Aspnetrun.Entities;
using System.Threading.Tasks;

namespace Aspnetrun.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> SendMessage(Contact contact);
        Task<Contact> Subscribe(string address);
    }
}
