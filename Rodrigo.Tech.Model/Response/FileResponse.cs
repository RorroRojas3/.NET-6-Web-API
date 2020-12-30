using System;

namespace Rodrigo.Tech.Model.Responses
{
    public class FileResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }
    }
}