package org.itstep;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.MalformedURLException;
import java.net.URL;

public class CopyResource {
    public static void main(String[] args) throws MalformedURLException {
        copyPage("https://itstep.dp.ua", "index.html");
    }

    private static void copyPage(String source, String filePath) throws MalformedURLException {
        URL url = new URL(source);
        try(InputStream inputStream = url.openStream();
            OutputStream outputStream = new FileOutputStream(filePath)){
            byte[] buffer = new byte[1024];
            int length;
            while ((length = inputStream.read(buffer)) > 0){
                outputStream.write(new String(buffer, 0, length).getBytes());
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
