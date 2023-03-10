using System;

namespace API.Domain.DTOs
{
    public class BlobDto
    {
        public string? Uri { get; set; }
        public string? Name { get; set; }
        public string? ContentType { get; set; }
        public Stream? Content { get; set; }
        public DateTimeOffset? LastModifiedDate { get; set; }
    }
}