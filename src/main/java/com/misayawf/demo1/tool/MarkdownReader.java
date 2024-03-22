package com.misayawf.demo1.tool;
import org.commonmark.node.Node;
import org.commonmark.parser.Parser;
import org.commonmark.renderer.html.HtmlRenderer;
import java.nio.file.Files;
import java.nio.file.Paths;

public class MarkdownReader
{
    public static String convertMarkdownToHtml(String markdownFilePath){
        try
        {
            String markdownContent = new String(Files.readAllBytes(Paths.get(markdownFilePath)));
            Parser parser = Parser.builder().build();
            Node document = parser.parse(markdownContent);
            HtmlRenderer renderer = HtmlRenderer.builder().build();
            return renderer.render(document);
        }catch(Exception e){
            e.printStackTrace();
            return "Error reading or parsing markdown files";
        }
    }
}
