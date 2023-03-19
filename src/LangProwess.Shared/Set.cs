using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangProwess.Shared;

public record Set(Guid? Id, string Name, string? Description, int? LastWordIndex,
	Language QueriesLanguage, Language AnswersLanguage, DateTimeOffset? CreatedAt, SetAccess Access, Guid? OwnerId);
