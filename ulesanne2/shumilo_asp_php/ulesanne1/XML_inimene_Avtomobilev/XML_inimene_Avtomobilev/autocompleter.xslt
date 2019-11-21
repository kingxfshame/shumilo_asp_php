<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
      
        <table class="table table-striped">
          <thead>
            <tr>
              <th scope="col">Emakeelne nimi</th>
              <th scope="col">Võõrkeelne nimi</th>
              <th scope="col">Sugu</th>
            </tr>
          </thead>
          <tbody>
            <xsl:for-each select="/nimed/nimi">
            <tr>
              <td>
                <xsl:value-of select="emakeelne"/>
              </td>
              <td>
                <xsl:value-of select="vorkkeelne"/>
                
              </td>
              <td>
                <xsl:value-of select="sugu"/>
              </td>
            </tr>


      </xsl:for-each>
          </tbody>
        </table>
      <h4>
        Вывод первой буквы с первого имени в XML файле :
        <xsl:value-of select="substring(/nimed/nimi[1]/emakeelne, 1, 1)"/>
      </h4>
      <h4>
        Количество букв в первом имени:
        <xsl:value-of select="string-length(/nimed/nimi[1]/emakeelne)"/>
      </h4>
      <h4>
        Количество данных в XML : 
        <xsl:value-of select="count(/nimed/nimi)"/>
      </h4>
      
    </xsl:template>
</xsl:stylesheet>
