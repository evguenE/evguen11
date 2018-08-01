<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>

  <xsl:template match="/">   
          <xsl:element name="request-stats">
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
  </xsl:template>
</xsl:stylesheet>
