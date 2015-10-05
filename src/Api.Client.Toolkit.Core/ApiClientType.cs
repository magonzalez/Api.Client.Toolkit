using System;

namespace Api.Client.Toolkit
{
    public class ApiClientType
    {
        public ApiClientType(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}
