using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangProwess.Shared;

public record User(Guid? Id, string? Username, string? Email, DateTimeOffset? CreatedAt);
