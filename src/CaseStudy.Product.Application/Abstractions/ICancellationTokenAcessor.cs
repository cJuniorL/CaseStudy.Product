using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Product.Application.Abstractions;

public interface ICancellationTokenAcessor
{
    CancellationToken Token { get; }
}

public record CancellationTokenAcessor(CancellationToken Token) : ICancellationTokenAcessor;