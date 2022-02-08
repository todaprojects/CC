# CC (_Caesar cipher algorithm_)
## Task
    - Implement Caesar Cipher algorithm (https://en.wikipedia.org/wiki/Caesar_cipher);
    - Cover solution with Unit Tests;
    - User interface is not required.

## Solution
   - Algorithm solution build on _**.NET Core 5.0**_;
   - Unit tests build using _**xUnit**_ testing tool, with _**Fluent Assertions**_ helper library.

## Using
- _Caesar Cipher_ object is initialized by passing integer _Cipher_ (_either positive or negative_) as constructor parameter.
- Encoding of plain text can be received by invoking _.Encode()_ method on the Caesar Cipher object, passing a string of plain text as parameter.
- Decoding of encrypted text can be received by invoking _.Decode()_ method on the Caesar Cipher object, passing a string of encrypted text as parameter.

```c#
    int cipherKey = 10;
    string plainText = "Hello world!";
        
    CaesarCipher caesarCipher = new CaesarCipher(cipherKey);
    string encryptedText = caesarCipher.Encrypt(plainText);
    string decryptedText = caesarCipher.Decrypt(encryptedText);

    Console.WriteLine(encryptedText);
    Console.WriteLine(decryptedText);
```
Console output of the above code example:

![img.png](img.png)