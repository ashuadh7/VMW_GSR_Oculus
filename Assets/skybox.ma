//Maya ASCII 2011 scene
//Name: skybox.ma
//Last modified: Wed, Nov 23, 2011 12:20:40 AM
//Codeset: UTF-8
requires maya "2011";
currentUnit -l centimeter -a degree -t ntsc;
fileInfo "application" "maya";
fileInfo "product" "Maya 2011";
fileInfo "version" "2011 x64";
fileInfo "cutIdentifier" "201003190347-771506";
fileInfo "osv" "Mac OS X 10.7.2";
createNode transform -n "world_all_tiles";
	setAttr ".s" -type "double3" 0.8 0.8 0.8 ;
createNode transform -n "Skybox" -p "world_all_tiles";
	setAttr ".v" no;
	setAttr ".s" -type "double3" 2.1625850909120432 2.1625850909120432 2.1625850909120432 ;
	setAttr ".rp" -type "double3" -505.63686523437502 -2036.0003906249999 22626.28125 ;
	setAttr ".sp" -type "double3" -632.04608154296648 -2545.00048828125 28282.851562500004 ;
	setAttr ".spt" -type "double3" 126.4092163085933 509.00009765625003 -5656.5703125000036 ;
	setAttr ".mnrl" -type "double3" 0 0 0 ;
	setAttr ".mxrl" -type "double3" 0 0 0 ;
createNode mesh -n "SkyboxShape" -p "Skybox";
	addAttr -ci true -sn "mso" -ln "miShadingSamplesOverride" -min 0 -max 1 -at "bool";
	addAttr -ci true -sn "msh" -ln "miShadingSamples" -min 0 -smx 8 -at "float";
	addAttr -ci true -sn "mdo" -ln "miMaxDisplaceOverride" -min 0 -max 1 -at "bool";
	addAttr -ci true -sn "mmd" -ln "miMaxDisplace" -min 0 -smx 1 -at "float";
	setAttr -k off ".v";
	setAttr -s 4 ".iog[0].og";
	setAttr ".iog[0].og[1].gcl" -type "componentList" 2 "f[5:9]" "f[20]";
	setAttr ".iog[0].og[3].gcl" -type "componentList" 1 "f[10:14]";
	setAttr ".iog[0].og[5].gcl" -type "componentList" 1 "f[15:19]";
	setAttr ".iog[0].og[7].gcl" -type "componentList" 1 "f[0:4]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "UVChannel_1";
	setAttr -s 68 ".uvst[0].uvsp[0:67]" -type "float2" 0 0.00050067902 
		0.17816716 0.00050064921 0.17816719 0.99950057 0 0.99950063 0.38776487 0.0005004406 
		0.38776487 0.99950039 0.60877556 0.00050011277 0.60877562 0.9995001 0.8195653 0.00049969554 
		0.8195653 0.99949968 1 0.0004992187 1 0.99949914 0 0.00050079823 0.18043467 0.00050067902 
		0.18043473 0.99950039 0 0.99950051 0.39122427 0.0005005002 0.39122432 0.99950016 
		0.61223501 0.00050020218 0.61223507 0.99949992 0.82183278 0.00049987435 0.82183278 
		0.99949956 1 0.00049954653 1 0.9994992 0 0.00050085783 0.18043467 0.00050073862 0.1804347 
		0.99950027 0 0.99950039 0.39122444 0.00050055981 0.3912245 0.99950004 0.61223525 
		0.00050029159 0.61223531 0.9994998 0.82183284 0.00049996376 0.8218329 0.99949944 
		1 0.00049966574 1 0.99949908 0 0.0005005002 0.18043485 0.0005004406 0.18043491 0.99950039 
		0 0.99950045 0.3912248 0.00050029159 0.39122486 0.99950027 0.61223572 0.00050008297 
		0.61223578 0.99950004 0.82183349 0.00049984455 0.82183349 0.9994998 1 0.00049957633 
		1 0.9994995 0.61034286 0.98873711 0.6107372 0.98796308 0.61135149 0.98734885 0.61212552 
		0.98695445 0.61298347 0.98681855 0.61384153 0.98695445 0.61461556 0.98734885 0.61522985 
		0.98796308 0.61562419 0.98873711 0.61576009 0.98959512 0.61562419 0.99045312 0.61522985 
		0.99122715 0.61461556 0.99184138 0.61384153 0.99223578 0.61298358 0.99237168 0.61212552 
		0.99223578 0.61135149 0.99184138 0.6107372 0.99122715 0.61034286 0.99045312 0.61020696 
		0.98959512;
	setAttr ".cuvs" -type "string" "UVChannel_1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".bnr" 0;
	setAttr -s 40 ".pt[0:39]" -type "float3"  17628.816 -2545.0051 43105.012 
		21315.371 -2660.3159 36621.332 22853.555 -2764.3394 29321.426 22092.807 -2846.8921 
		21919.855 19107.594 -2899.8936 15141.135 14190.125 -2918.1558 9648.8232 7821.7588 
		-2899.8906 5980.5371 625.87683 -2846.8867 4495.3584 -6693.1406 -2764.3315 5338.6641 
		-13418.859 -2660.3074 8427.9092 -18892.914 -2544.9961 13460.696 -22579.465 -2429.6846 
		19944.379 -24117.648 -2325.6614 27244.293 -23356.895 -2243.1089 34645.863 -20371.674 
		-2190.1072 41424.582 -15454.199 -2171.8452 46916.895 -9085.8281 -2190.1104 50585.172 
		-1889.9395 -2243.1145 52070.352 5429.0796 -2325.6694 51227.031 12154.793 -2429.6941 
		48137.777 17628.824 32325.203 43005.016 21315.377 32209.895 36521.336 22853.561 32105.871 
		29221.43 22092.812 32023.316 21819.857 19107.598 31970.316 15041.141 14190.131 31952.057 
		9548.8262 7821.7637 31970.316 5880.541 625.88257 32023.322 4395.3623 -6693.1357 32105.877 
		5238.668 -13418.853 32209.902 8327.9121 -18892.906 32325.215 13360.699 -22579.459 
		32440.523 19844.383 -24117.643 32544.547 27144.297 -23356.889 32627.1 34545.867 -20371.668 
		32680.102 41324.586 -15454.193 32698.365 46816.898 -9085.8223 32680.094 50485.18 
		-1889.9338 32627.094 51970.352 5429.085 32544.541 51127.039 12154.798 32440.516 48037.781;
	setAttr -s 40 ".vt[0:39]"  373.15469 0 0 354.8912 115.31115 0 301.88849 
		219.33482 0 219.33482 301.88849 0 115.31112 354.8912 0 -1.6311111e-05 373.15469 0 
		-115.31116 354.8912 0 -219.33482 301.88849 0 -301.88849 219.33482 0 -354.89124 115.31107 
		0 -373.15469 -0.00012158923 0 -354.89114 -115.3113 0 -301.88837 -219.33501 0 -219.33459 
		-301.88864 0 -115.31085 -354.8913 0 0.00036031788 -373.15469 0 115.31153 -354.89108 
		0 219.33521 -301.88821 0 301.88879 -219.33441 0 354.89139 -115.31062 0 373.15469 
		0 100 354.8912 115.31115 100 301.88849 219.33482 100 219.33482 301.88849 100 115.31112 
		354.8912 100 -1.6311111e-05 373.15469 100 -115.31116 354.8912 100 -219.33482 301.88849 
		100 -301.88849 219.33482 100 -354.89124 115.31107 100 -373.15469 -0.00012158923 100 
		-354.89114 -115.3113 100 -301.88837 -219.33501 100 -219.33459 -301.88864 100 -115.31085 
		-354.8913 100 0.00036031788 -373.15469 100 115.31153 -354.89108 100 219.33521 -301.88821 
		100 301.88879 -219.33441 100 354.89139 -115.31062 100;
	setAttr -s 60 ".ed[0:59]"  0 20 1 20 21 0 
		21 1 1 1 0 0 21 22 0 22 2 1 
		2 1 0 22 23 0 23 3 1 3 2 0 
		23 24 0 24 4 1 4 3 0 24 25 0 
		25 5 1 5 4 0 25 26 0 26 6 1 
		6 5 0 26 27 0 27 7 1 7 6 0 
		27 28 0 28 8 1 8 7 0 28 29 0 
		29 9 1 9 8 0 29 30 0 30 10 1 
		10 9 0 30 31 0 31 11 1 11 10 0 
		31 32 0 32 12 1 12 11 0 32 33 0 
		33 13 1 13 12 0 33 34 0 34 14 1 
		14 13 0 34 35 0 35 15 1 15 14 0 
		35 36 0 36 16 1 16 15 0 36 37 0 
		37 17 1 17 16 0 37 38 0 38 18 1 
		18 17 0 38 39 0 39 19 1 19 18 0 
		39 20 0 0 19 0;
	setAttr -s 60 ".n[0:59]" -type "float3"  1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 
		1e+20 1e+20 1e+20 1e+20 1e+20 1e+20 1e+20;
	setAttr -s 21 ".fc[0:20]" -type "polyFaces" 
		f 4 0 1 2 3 
		mu 0 4 0 3 2 1 
		f 4 -3 4 5 6 
		mu 0 4 1 2 5 4 
		f 4 -6 7 8 9 
		mu 0 4 4 5 7 6 
		f 4 -9 10 11 12 
		mu 0 4 6 7 9 8 
		f 4 -12 13 14 15 
		mu 0 4 8 9 11 10 
		f 4 -15 16 17 18 
		mu 0 4 12 15 14 13 
		f 4 -18 19 20 21 
		mu 0 4 13 14 17 16 
		f 4 -21 22 23 24 
		mu 0 4 16 17 19 18 
		f 4 -24 25 26 27 
		mu 0 4 18 19 21 20 
		f 4 -27 28 29 30 
		mu 0 4 20 21 23 22 
		f 4 -30 31 32 33 
		mu 0 4 24 27 26 25 
		f 4 -33 34 35 36 
		mu 0 4 25 26 29 28 
		f 4 -36 37 38 39 
		mu 0 4 28 29 31 30 
		f 4 -39 40 41 42 
		mu 0 4 30 31 33 32 
		f 4 -42 43 44 45 
		mu 0 4 32 33 35 34 
		f 4 -45 46 47 48 
		mu 0 4 36 39 38 37 
		f 4 -48 49 50 51 
		mu 0 4 37 38 41 40 
		f 4 -51 52 53 54 
		mu 0 4 40 41 43 42 
		f 4 -54 55 56 57 
		mu 0 4 42 43 45 44 
		f 4 -57 58 -1 59 
		mu 0 4 44 45 47 46 
		f 20 -5 -2 -59 -56 -53 -50 -47 -44 -41 -38 
		-35 -32 -29 -26 -23 -20 -17 -14 -11 -8 
		mu 0 20 65 66 67 48 49 50 51 52 53 
		54 55 56 57 58 59 60 61 62 63 64 ;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode groupId -n "tile3_groupId1826";
	setAttr ".ihi" 0;
createNode shadingEngine -n "Cylinder03SG";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo264";
createNode phong -n "skyA1_mt";
	setAttr ".dc" 1;
	setAttr ".ambc" -type "float3" 0.588 0.588 0.588 ;
	setAttr ".sc" -type "float3" 0 0 0 ;
	setAttr ".cp" 2;
createNode file -n "skyA1_tx";
	setAttr ".ftn" -type "string" "C:/firsthand/Cool!/CoolArt/worlds/sourceimages/SkyA1.tga";
createNode place2dTexture -n "place2dTexture35";
createNode groupId -n "tile3_groupId1828";
	setAttr ".ihi" 0;
createNode shadingEngine -n "Cylinder03SG1";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo265";
createNode phong -n "skyA2_mt";
	setAttr ".dc" 1;
	setAttr ".ambc" -type "float3" 0.588 0.588 0.588 ;
	setAttr ".sc" -type "float3" 0 0 0 ;
	setAttr ".cp" 2;
createNode file -n "skyA2_tx";
	setAttr ".ftn" -type "string" "C:/firsthand/Cool!/CoolArt/worlds/sourceimages/SkyA2.tga";
createNode place2dTexture -n "place2dTexture36";
createNode groupId -n "tile3_groupId1830";
	setAttr ".ihi" 0;
createNode shadingEngine -n "Cylinder03SG2";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo266";
createNode phong -n "skyA3_mt";
	setAttr ".dc" 1;
	setAttr ".ambc" -type "float3" 0.588 0.588 0.588 ;
	setAttr ".sc" -type "float3" 0 0 0 ;
	setAttr ".cp" 2;
createNode file -n "skyA3_tx";
	setAttr ".ftn" -type "string" "C:/firsthand/Cool!/CoolArt/worlds/sourceimages/SkyA3.tga";
createNode place2dTexture -n "place2dTexture37";
createNode groupId -n "tile3_groupId1832";
	setAttr ".ihi" 0;
createNode shadingEngine -n "Cylinder03SG3";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo267";
createNode phong -n "skyA4_mt";
	setAttr ".dc" 1;
	setAttr ".ambc" -type "float3" 0.588 0.588 0.588 ;
	setAttr ".sc" -type "float3" 0 0 0 ;
	setAttr ".cp" 2;
createNode file -n "skyA4_tx";
	setAttr ".ftn" -type "string" "C:/firsthand/Cool!/CoolArt/worlds/sourceimages/SkyA4.tga";
createNode place2dTexture -n "place2dTexture34";
createNode lightLinker -s -n "lightLinker1";
	setAttr -s 3178 ".lnk";
	setAttr -s 3178 ".slnk";
select -ne :time1;
	setAttr -av -k on ".cch";
	setAttr -k on ".nds";
	setAttr -cb on ".bnm";
	setAttr -k on ".o" 1;
	setAttr ".unw" 1;
select -ne :renderPartition;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -cb on ".bnm";
	setAttr -s 3178 ".st";
select -ne :initialShadingGroup;
	setAttr -k on ".cch";
	setAttr -av -k on ".nds";
	setAttr -cb on ".bnm";
	setAttr -s 2 ".dsm";
	setAttr -k on ".mwc";
	setAttr ".ro" yes;
	setAttr -cb on ".mimt";
	setAttr -cb on ".miop";
	setAttr -cb on ".mise";
	setAttr -cb on ".mism";
	setAttr -cb on ".mice";
	setAttr -av ".micc";
	setAttr -cb on ".mica";
	setAttr -cb on ".micw";
	setAttr -cb on ".mirw";
select -ne :initialParticleSE;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -cb on ".bnm";
	setAttr -k on ".mwc";
	setAttr ".ro" yes;
	setAttr -cb on ".mimt";
	setAttr -cb on ".miop";
	setAttr -cb on ".mise";
	setAttr -cb on ".mism";
	setAttr -cb on ".mice";
	setAttr -cb on ".micc";
	setAttr -cb on ".mica";
	setAttr -cb on ".micw";
	setAttr -cb on ".mirw";
select -ne :defaultShaderList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -cb on ".bnm";
	setAttr -s 49 ".s";
select -ne :defaultTextureList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -s 86 ".tx";
select -ne :lightList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -cb on ".bnm";
	setAttr -s 14 ".l";
select -ne :postProcessList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -cb on ".bnm";
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -s 86 ".u";
select -ne :renderGlobalsList1;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -cb on ".bnm";
select -ne :defaultLightSet;
	setAttr -k on ".cch";
	setAttr -k on ".nds";
	setAttr -s 14 ".dsm";
	setAttr -k on ".mwc";
	setAttr ".ro" yes;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :defaultHardwareRenderGlobals;
	setAttr -k on ".cch";
	setAttr -cb on ".ihi";
	setAttr -k on ".nds";
	setAttr -cb on ".bnm";
	setAttr -k on ".rp";
	setAttr -k on ".cai";
	setAttr -k on ".coi";
	setAttr -cb on ".bc";
	setAttr -av -k on ".bcb";
	setAttr -av -k on ".bcg";
	setAttr -av -k on ".bcr";
	setAttr -k on ".ei";
	setAttr -k on ".ex";
	setAttr -k on ".es";
	setAttr -av -k on ".ef";
	setAttr -k on ".bf";
	setAttr -k on ".fii";
	setAttr -k on ".sf";
	setAttr -k on ".gr";
	setAttr -k on ".li";
	setAttr -k on ".ls";
	setAttr -k on ".mb";
	setAttr -k on ".ti";
	setAttr -k on ".txt";
	setAttr -k on ".mpr";
	setAttr -k on ".wzd";
	setAttr ".fn" -type "string" "im";
	setAttr -k on ".if";
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
	setAttr -k on ".as";
	setAttr -k on ".ds";
	setAttr -k on ".lm";
	setAttr -k on ".fir";
	setAttr -k on ".aap";
	setAttr -k on ".gh";
	setAttr -cb on ".sd";
select -ne :hyperGraphLayout;
	setAttr -s 50 ".hyp";
	setAttr ".hyp[0].isc" yes;
	setAttr ".hyp[3].isc" yes;
	setAttr ".hyp[5].isc" yes;
	setAttr ".hyp[6].isc" yes;
	setAttr ".hyp[7].isc" yes;
	setAttr ".hyp[8].isc" yes;
	setAttr ".hyp[9].isc" yes;
	setAttr ".hyp[51].isc" yes;
	setAttr ".hyp[52].isc" yes;
	setAttr ".hyp[53].isc" yes;
	setAttr ".hyp[54].isc" yes;
	setAttr ".hyp[55].isc" yes;
	setAttr ".hyp[78].isc" yes;
	setAttr ".hyp[79].isc" yes;
	setAttr ".hyp[80].isc" yes;
	setAttr ".hyp[124].isc" yes;
	setAttr ".hyp[130].isc" yes;
	setAttr ".hyp[131].isc" yes;
	setAttr ".hyp[132].isc" yes;
	setAttr ".hyp[133].isc" yes;
	setAttr ".hyp[134].isc" yes;
	setAttr ".hyp[135].isc" yes;
	setAttr ".hyp[136].isc" yes;
	setAttr ".hyp[137].isc" yes;
	setAttr ".hyp[138].isc" yes;
	setAttr ".hyp[139].isc" yes;
	setAttr ".hyp[140].isc" yes;
	setAttr ".hyp[141].isc" yes;
	setAttr ".hyp[142].isc" yes;
	setAttr ".hyp[143].isc" yes;
	setAttr ".hyp[144].isc" yes;
	setAttr ".hyp[145].isc" yes;
	setAttr ".hyp[147].isc" yes;
	setAttr ".hyp[148].isc" yes;
	setAttr ".hyp[151].isc" yes;
	setAttr ".hyp[153].isc" yes;
	setAttr ".hyp[154].isc" yes;
	setAttr ".hyp[156].isc" yes;
	setAttr ".hyp[157].isc" yes;
	setAttr ".hyp[158].isc" yes;
	setAttr ".hyp[159].isc" yes;
	setAttr ".hyp[282].isc" yes;
	setAttr ".hyp[284].isc" yes;
	setAttr ".hyp[285].isc" yes;
	setAttr ".hyp[286].isc" yes;
	setAttr ".hyp[287].isc" yes;
	setAttr ".hyp[288].isc" yes;
	setAttr ".hyp[289].isc" yes;
	setAttr ".hyp[290].isc" yes;
	setAttr ".hyp[291].isc" yes;
connectAttr "tile3_groupId1826.id" "SkyboxShape.iog.og[1].gid";
connectAttr "Cylinder03SG.mwc" "SkyboxShape.iog.og[1].gco";
connectAttr "tile3_groupId1828.id" "SkyboxShape.iog.og[3].gid";
connectAttr "Cylinder03SG1.mwc" "SkyboxShape.iog.og[3].gco";
connectAttr "tile3_groupId1830.id" "SkyboxShape.iog.og[5].gid";
connectAttr "Cylinder03SG2.mwc" "SkyboxShape.iog.og[5].gco";
connectAttr "tile3_groupId1832.id" "SkyboxShape.iog.og[7].gid";
connectAttr "Cylinder03SG3.mwc" "SkyboxShape.iog.og[7].gco";
connectAttr "skyA1_mt.oc" "Cylinder03SG.ss";
connectAttr "SkyboxShape.iog.og[1]" "Cylinder03SG.dsm" -na;
connectAttr "Cylinder03SG.msg" "materialInfo264.sg";
connectAttr "skyA1_mt.msg" "materialInfo264.m";
connectAttr "skyA1_tx.msg" "materialInfo264.t" -na;
connectAttr "skyA1_tx.oc" "skyA1_mt.c";
connectAttr "place2dTexture35.o" "skyA1_tx.uv";
connectAttr "place2dTexture35.ofu" "skyA1_tx.ofu";
connectAttr "place2dTexture35.ofv" "skyA1_tx.ofv";
connectAttr "place2dTexture35.rf" "skyA1_tx.rf";
connectAttr "place2dTexture35.reu" "skyA1_tx.reu";
connectAttr "place2dTexture35.rev" "skyA1_tx.rev";
connectAttr "place2dTexture35.vt1" "skyA1_tx.vt1";
connectAttr "place2dTexture35.vt2" "skyA1_tx.vt2";
connectAttr "place2dTexture35.vt3" "skyA1_tx.vt3";
connectAttr "place2dTexture35.vc1" "skyA1_tx.vc1";
connectAttr "place2dTexture35.ofs" "skyA1_tx.fs";
connectAttr "skyA2_mt.oc" "Cylinder03SG1.ss";
connectAttr "SkyboxShape.iog.og[3]" "Cylinder03SG1.dsm" -na;
connectAttr "Cylinder03SG1.msg" "materialInfo265.sg";
connectAttr "skyA2_mt.msg" "materialInfo265.m";
connectAttr "skyA2_tx.msg" "materialInfo265.t" -na;
connectAttr "skyA2_tx.oc" "skyA2_mt.c";
connectAttr "place2dTexture36.o" "skyA2_tx.uv";
connectAttr "place2dTexture36.ofu" "skyA2_tx.ofu";
connectAttr "place2dTexture36.ofv" "skyA2_tx.ofv";
connectAttr "place2dTexture36.rf" "skyA2_tx.rf";
connectAttr "place2dTexture36.reu" "skyA2_tx.reu";
connectAttr "place2dTexture36.rev" "skyA2_tx.rev";
connectAttr "place2dTexture36.vt1" "skyA2_tx.vt1";
connectAttr "place2dTexture36.vt2" "skyA2_tx.vt2";
connectAttr "place2dTexture36.vt3" "skyA2_tx.vt3";
connectAttr "place2dTexture36.vc1" "skyA2_tx.vc1";
connectAttr "place2dTexture36.ofs" "skyA2_tx.fs";
connectAttr "skyA3_mt.oc" "Cylinder03SG2.ss";
connectAttr "SkyboxShape.iog.og[5]" "Cylinder03SG2.dsm" -na;
connectAttr "Cylinder03SG2.msg" "materialInfo266.sg";
connectAttr "skyA3_mt.msg" "materialInfo266.m";
connectAttr "skyA3_tx.msg" "materialInfo266.t" -na;
connectAttr "skyA3_tx.oc" "skyA3_mt.c";
connectAttr "place2dTexture37.o" "skyA3_tx.uv";
connectAttr "place2dTexture37.ofu" "skyA3_tx.ofu";
connectAttr "place2dTexture37.ofv" "skyA3_tx.ofv";
connectAttr "place2dTexture37.rf" "skyA3_tx.rf";
connectAttr "place2dTexture37.reu" "skyA3_tx.reu";
connectAttr "place2dTexture37.rev" "skyA3_tx.rev";
connectAttr "place2dTexture37.vt1" "skyA3_tx.vt1";
connectAttr "place2dTexture37.vt2" "skyA3_tx.vt2";
connectAttr "place2dTexture37.vt3" "skyA3_tx.vt3";
connectAttr "place2dTexture37.vc1" "skyA3_tx.vc1";
connectAttr "place2dTexture37.ofs" "skyA3_tx.fs";
connectAttr "skyA4_mt.oc" "Cylinder03SG3.ss";
connectAttr "SkyboxShape.iog.og[7]" "Cylinder03SG3.dsm" -na;
connectAttr "Cylinder03SG3.msg" "materialInfo267.sg";
connectAttr "skyA4_mt.msg" "materialInfo267.m";
connectAttr "skyA4_tx.msg" "materialInfo267.t" -na;
connectAttr "skyA4_tx.oc" "skyA4_mt.c";
connectAttr "place2dTexture34.o" "skyA4_tx.uv";
connectAttr "place2dTexture34.ofu" "skyA4_tx.ofu";
connectAttr "place2dTexture34.ofv" "skyA4_tx.ofv";
connectAttr "place2dTexture34.rf" "skyA4_tx.rf";
connectAttr "place2dTexture34.reu" "skyA4_tx.reu";
connectAttr "place2dTexture34.rev" "skyA4_tx.rev";
connectAttr "place2dTexture34.vt1" "skyA4_tx.vt1";
connectAttr "place2dTexture34.vt2" "skyA4_tx.vt2";
connectAttr "place2dTexture34.vt3" "skyA4_tx.vt3";
connectAttr "place2dTexture34.vc1" "skyA4_tx.vc1";
connectAttr "place2dTexture34.ofs" "skyA4_tx.fs";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "Cylinder03SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "Cylinder03SG1.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "Cylinder03SG2.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "Cylinder03SG3.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "Cylinder03SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "Cylinder03SG1.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "Cylinder03SG2.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "Cylinder03SG3.message" ":defaultLightSet.message";
connectAttr "Cylinder03SG.pa" ":renderPartition.st" -na;
connectAttr "Cylinder03SG1.pa" ":renderPartition.st" -na;
connectAttr "Cylinder03SG2.pa" ":renderPartition.st" -na;
connectAttr "Cylinder03SG3.pa" ":renderPartition.st" -na;
connectAttr "skyA1_mt.msg" ":defaultShaderList1.s" -na;
connectAttr "skyA2_mt.msg" ":defaultShaderList1.s" -na;
connectAttr "skyA3_mt.msg" ":defaultShaderList1.s" -na;
connectAttr "skyA4_mt.msg" ":defaultShaderList1.s" -na;
connectAttr "skyA4_tx.msg" ":defaultTextureList1.tx" -na;
connectAttr "skyA1_tx.msg" ":defaultTextureList1.tx" -na;
connectAttr "skyA2_tx.msg" ":defaultTextureList1.tx" -na;
connectAttr "skyA3_tx.msg" ":defaultTextureList1.tx" -na;
connectAttr "place2dTexture34.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture35.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture36.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture37.msg" ":defaultRenderUtilityList1.u" -na;
// End of skybox.ma
