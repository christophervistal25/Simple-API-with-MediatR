namespace App.Core.Contracts;

public interface IDbContext
{
    /// <summary>
    /// Need nato muhimo na ine kay para makaoverride
    /// kita sa sulod ng AppDbContext
    /// without ine mag lisod kita pag implement ng
    /// Create and Update feature sa ato API
    /// I-check ang AppDbContext yaka implement si IAppDbContext
    /// pero sa sulod ng IAppDbContext yaun ngadto yaka inherit ine na interface
    /// although wara mag notif sa ato na need nato i-implement ine na method
    /// kinahanglan nato i-override ang ine inside sa AppDbContext
    /// para makapag perform kita ng Create ug Update ug kung naa pay
    /// ato gusto na i-perform na mga small changes before or after
    /// mag Create or Update kita ng record sa Database.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}