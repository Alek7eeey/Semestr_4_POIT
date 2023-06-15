package com.example.ex_3;

import jakarta.servlet.jsp.JspException;
import jakarta.servlet.jsp.JspWriter;
import jakarta.servlet.jsp.tagext.TagSupport;

import java.io.IOException;

@SuppressWarnings("serial")
public class MyTag extends TagSupport
{
    @Override
    public int doStartTag() throws JspException
    {
        JspWriter out = pageContext.getOut();
        try {
            out.println("        <form action=\"ControllerForTag\">\n" +
                    "            <input type=\"text\" name=\"numberDoc\" placeholder=\"Номер документа\" required>\n" +
                    "            <button type=\"submit\" name=\"action\" value=\"check\">Check</button>\n" +
                    "        </form>");

        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        return SKIP_BODY;
    }
}
