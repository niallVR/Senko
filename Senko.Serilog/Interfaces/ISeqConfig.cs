namespace NiallVR.Senko.Serilog.Interfaces; 

public interface ISeqConfig {
    /// <summary>
    /// The HTTP address to the Seq server.
    /// </summary>
    public string Host { get; }
    
    /// <summary>
    /// The authentication token for the Seq API.
    /// </summary>
    public string Token { get; }
}