package com.example.netchat_app;

import javax.crypto.Cipher;
import javax.crypto.KeyGenerator;
import javax.crypto.SecretKey;

public class CypherCryption {

    public byte[] encrypt(byte[] plaintext){

        KeyGenerator keygen = KeyGenerator.getInstance("AES");
        keygen.init(256);
        SecretKey key = keygen.generateKey();
        Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5PADDING");
        cipher.init(Cipher.ENCRYPT_MODE, key);
        byte[] ciphertext = cipher.doFinal(plaintext);
        byte[] iv = cipher.getIV();

    return ciphertext;
    }


}
