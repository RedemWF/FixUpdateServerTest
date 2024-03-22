package com.misayawf.demo1.controller;

import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.text.SimpleDateFormat;
import java.util.Date;

@RestController
public class UploadController
{
    @RequestMapping(value = "/fileLoad",method = RequestMethod.POST)
    public String uploadFile(@RequestParam("file")MultipartFile file, Model model){
        if (file.isEmpty()){
            model.addAttribute("msg","上传文件错误！");
        }
        else{

            String filename=file.getOriginalFilename();
            Path path = Paths.get("G:\\Resources/"+filename);
            model.addAttribute("msg","文件上传成功");
            model.addAttribute("src",filename);
            try{
                Files.write(path,file.getBytes());
            }catch (Exception e){
                e.printStackTrace();
                model.addAttribute("msg","上传失败！");
            }
        }
        return "status";
    }
}
