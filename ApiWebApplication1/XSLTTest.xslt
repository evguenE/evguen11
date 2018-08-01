<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

  <!--<xsl:template match="/">

    <html>
      <body>
        <h2>Тип вопроса</h2>
        <xsl:apply-templates/>
      </body>
    </html>
  </xsl:template>-->
  
  <xsl:template match="/service">
    <!--<html>
      <body>
    <table border="1" style= "border-collapse: collapse;">
      <tr bgcolor="gray">
        <th>Тип вопроса</th>
        <th>Колличество вопросов</th>
      </tr>-->
      <xsl:for-each select="request-types/type">
        <xsl:variable name="idd" select="@id"/>
        <!--<tr>
          
          <td>-->
            <xsl:apply-templates select="@caption"/>
          <!--</td>
          <td>-->
            <xsl:value-of select = 'count(/service/requests/request[@type = $idd])'/>
          <!--</td>
        </tr>-->
      </xsl:for-each>
    <!--</table>
    </body>
    </html>-->
  </xsl:template>  
    
  <!--<xsl:element name="request-stats">
            <xsl:for-each select="service/request-types/type">
              <xsl:element name="request">
                <xsl:variable name="idd" select="@id"/>
               
                    <xsl:attribute name="type-caption">
                      <xsl:value-of select="@caption" />
                    </xsl:attribute>
                
                    <xsl:attribute name="count">
                      <xsl:value-of select="count(/service/requests/request[@type = $idd])"/>
                    </xsl:attribute>
               
              </xsl:element>
            </xsl:for-each>
          </xsl:element>
  </xsl:template>-->
     

 

</xsl:stylesheet>
