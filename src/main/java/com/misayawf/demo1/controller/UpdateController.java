package com.misayawf.demo1.controller;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.ServletOutputStream;
import jakarta.servlet.http.HttpServletResponse;
import org.apache.tomcat.util.http.fileupload.IOUtils;
import org.springframework.http.HttpHeaders;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import java.io.File;
import java.io.FileInputStream;
import java.net.URLEncoder;
import java.nio.charset.StandardCharsets;

@RestController
public class UpdateController
{
    @GetMapping("/update")
    public void update(@RequestParam("filename")String filename,
                         HttpServletRequest request,
                         HttpServletResponse response) throws Exception{
        try {
            //String realPath = ResourceUtils.getURL("classpath:").getPath() + "/static/files";
            String realPath ="G:\\Resources";
            //获取文件输入流
            File file = new File(realPath, filename);
            FileInputStream inputStream = new FileInputStream(file);
            //相应输出流
            ServletOutputStream outputStream = response.getOutputStream();


            String agent = request.getHeader(HttpHeaders.USER_AGENT);
            filename = URLEncoder.encode(filename, StandardCharsets.UTF_8.name());

            response.setCharacterEncoding(StandardCharsets.UTF_8.name());
            // Content-Disposition的作用：告知浏览器以何种方式显示响应返回的文件，用浏览器打开还是以附件的形式下载到本地保存
            // attachment表示以附件方式下载   inline表示在线打开
            // filename表示文件的默认名称，因为网络传输只支持URL编码，因此需要将文件名URL编码后进行传输,前端收到后需要反编码才能获取到真正的名称
            response.setHeader(HttpHeaders.CONTENT_DISPOSITION,
                    "attachment;filename=" + URLEncoder.encode(filename, StandardCharsets.UTF_8.name()));
            // 告知浏览器文件的大小
            response.setHeader(HttpHeaders.CONTENT_LENGTH, String.valueOf(file.length()));

            IOUtils.copy(inputStream, outputStream);
            IOUtils.closeQuietly(inputStream);
            IOUtils.closeQuietly(outputStream);
        } catch (Exception ex) {
            ex.printStackTrace();
        }

    }
}
