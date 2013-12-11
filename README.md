Ioc Performance
===============

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](http://www.palmmedia.de)  
Twitter: [@danielpalme](http://twitter.com/danielpalme)  

Results
-------
<table>
<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th><th>Complex</th></tr>
<tr><th>No</th><td>81</td><td>88</td><td>97</td><td>106</td></tr>
<tr><th>Autofac 3.1.5 (http://code.google.com/p/autofac)</th><td>978</td><td>713</td><td>1674</td><td>5042</td></tr>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>435</td><td>409</td><td>1132</td><td>4488</td></tr>
<tr><th>Catel 3.8 (http://www.catelproject.com)</th><td>441</td><td>3856</td><td>9559</td><td>24594</td></tr>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>98</td><td>105</td><td>164</td><td>444</td></tr>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><th>86</th><td>113</td><td>140</td><td>216</td></tr>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>127</td><td>131</td><td>289</td><td>952</td></tr>
<tr><th>Grace 1.0 (http://grace.codeplex.com)</th><td>471</td><td>444</td><td>686</td><td>1707</td></tr>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td>207</td><td>262</td><td>552</td><td>1475</td></tr>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>102</td><th>99</th><th>113</th><td>158</td></tr>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>130</td><td>123</td><td>183</td><td>191</td></tr>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>109</td><td>127</td><td>135</td><td>176</td></tr>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>451</td><td>2871</td><td>19797</td><td>102595</td></tr>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><td>104</td><td>123</td><td>123</td><th>146</th></tr>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td>6384</td><td>28237</td><td>70343</td><td>189899</td></tr>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>532</td><td>456</td><td>1249</td><td>3542</td></tr>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>36949</td><td>40471</td><td>67467</td><td>131693</td></tr>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td>335</td><td>956</td><td>3057</td><td>8282</td></tr>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>808</td><td>877</td><td>2169</td><td>7957</td></tr>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td>92</td><td>127</td><td>411</td><td>1355</td></tr>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>8997</td><td>18530</td><td>50983</td><td>138221</td></tr>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>5715</td><td>5375</td><td>5651</td><td>7121</td></tr>
<tr><th>SimpleInjector 2.4.0 (http://simpleinjector.codeplex.com)</th><td>109</td><td>116</td><td>126</td><td>153</td></tr>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>1641</td><td>16664</td><td>40305</td><td>101881</td></tr>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>2178</td><td>2009</td><td>5984</td><td>15834</td></tr>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td>463</td><td>436</td><td>619</td><td>1274</td></tr>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>601</td><td>2723</td><td>9101</td><td>34886</td></tr>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>2915</td><td>4009</td><td>11660</td><td>33348</td></tr>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>931</td><td>2700</td><td>8108</td><td>20969</td></tr>
</table>
Advanced Features
<table>
<tr><th>Container</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Interception</th></tr>
<tr><th>No</th><td>118</td><td>89</td><td>193</td><td>157</td><td></td></tr>
<tr><th>Autofac 3.1.5 (http://code.google.com/p/autofac)</th><td>4932</td><td>3736</td><td>5021</td><td></td><td>24946</td></tr>
<tr><th>Caliburn.Micro 1.5.2 (http://caliburnmicro.codeplex.com)</th><td>5810</td><td></td><td>5222</td><td></td><td></td></tr>
<tr><th>Catel 3.8 (http://www.catelproject.com)</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Dynamo 3.0.2.0 (http://www.dynamoioc.com)</th><td>584</td><td></td><td></td><td></td><td></td></tr>
<tr><th>fFastInjector 0.8.1 (http://ffastinjector.codeplex.com)</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Funq 1.0.0.0 (http://funq.codeplex.com)</th><td>962</td><td></td><td></td><td></td><td></td></tr>
<tr><th>Grace 1.0 (http://grace.codeplex.com)</th><td>1928</td><td>1190</td><td>2387</td><td>1580</td><td>6296</td></tr>
<tr><th>Griffin 1.1.0 (https://github.com/jgauffin/griffin.container)</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>HaveBox 1.6.1 (https://bitbucket.org/Have/havebox)</th><td>888</td><td></td><td>481</td><td></td><th>577</th></tr>
<tr><th>Hiro 1.0.3 (https://github.com/philiplaureano/Hiro)</th><td>1880</td><td></td><td></td><td></td><td></td></tr>
<tr><th>IfInjector 0.8.1 (https://github.com/iamahern/IfInjector)</th><td>295</td><td>125</td><td></td><td></td><td></td></tr>
<tr><th>LightCore 1.5.1 (http://www.lightcore.ch)</th><td>2111</td><td>12611</td><td>30342</td><td></td><td></td></tr>
<tr><th>LightInject 3.0.1.2 (https://github.com/seesharper/LightInject)</th><th>166</th><td>118</td><th>155</th><th>202</th><td></td></tr>
<tr><th>LinFu 2.3.0.41559 (https://github.com/philiplaureano/LinFu)</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Maestro 1.3.1 (https://github.com/JonasSamuelsson/Maestro)</th><td>6238</td><td>878</td><td>6153</td><td>2250</td><td>7305</td></tr>
<tr><th>Mef 4.0.0.0 (http://mef.codeplex.com)</th><td>139083</td><td>156400</td><td>103587</td><td></td><td></td></tr>
<tr><th>MicroSliver 2.1.6.0 (http://microsliver.codeplex.com)</th><td></td><td></td><td></td><td></td><td></td></tr>
<tr><th>Mugen 3.5.1 (http://mugeninjection.codeplex.com)</th><td>9774</td><td>7483</td><td>6901</td><td>3562</td><td>21569</td></tr>
<tr><th>Munq 3.1.6 (http://munq.codeplex.com)</th><td>1160</td><td></td><td></td><td></td><td></td></tr>
<tr><th>Ninject 3.0.1.10 (http://ninject.org)</th><td>131647</td><td>57254</td><td>113691</td><td>79990</td><td>26303</td></tr>
<tr><th>Petite 0.3.2 (https://github.com/andlju/Petite)</th><td>9532</td><td></td><td></td><td></td><td></td></tr>
<tr><th>SimpleInjector 2.4.0 (http://simpleinjector.codeplex.com)</th><td>205</td><th>111</th><td>260</td><td>395</td><td>9627</td></tr>
<tr><th>Spring.NET 1.3.2 (http://www.springframework.net/)</th><td>98173</td><td></td><td></td><td></td><td></td></tr>
<tr><th>StructureMap 2.6.4.1 (http://structuremap.net/structuremap)</th><td>19103</td><td>4577</td><td>19800</td><td></td><td>11168</td></tr>
<tr><th>StyleMVVM 3.1.4 (http://stylemvvm.codeplex.com)</th><td>1316</td><td>1042</td><td>2604</td><td>1992</td><td></td></tr>
<tr><th>TinyIoC 1.2 (https://github.com/grumpydev/TinyIoC)</th><td>4309</td><td>12615</td><td></td><td></td><td></td></tr>
<tr><th>Unity 3.0.1304.1 (http://msdn.microsoft.com/unity)</th><td>34445</td><td></td><td>54482</td><td></td><td>110279</td></tr>
<tr><th>Windsor 3.2.1 (http://castleproject.org)</th><td>42784</td><td>7387</td><td>22505</td><td></td><td>18511</td></tr>
</table>
