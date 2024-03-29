#define PI 3.1415926535897931
#define TIME _Time.y

sampler2D _TextureSprite;
sampler2D _TextureChannel0;
sampler2D _TextureChannel1;
sampler2D _TextureChannel2;
sampler2D _TextureChannel3;
           
float _OverlaySelection;
float _StickerType;
float _MotionState;
float4 _BorderColor;
float _BorderSizeOne;
float _BorderSizeTwo;
float _BorderBlurriness;
float _RangeSOne_One0; 
float _RangeSOne_One1; 
float _RangeSOne_One2; 
float _RangeSOne_One3; 
float _RangeSTen_Ten0;
float _RangeSTen_Ten1;
float _RangeSTen_Ten2;
float _RangeSTen_Ten3;
float _InVariableTick;
float _InVariableRatioX;
float _InVariableRatioY;
float4 _OutlineColor;
float _OutlineSprite;
float4 _ColorGlowHDR;
float _AlphaColor;
float _GlowFull;

#include "FolderIncludes/SDfs.hlsl"
#include "FolderIncludes/Stickers.hlsl"
#include "FolderIncludes/Sprites.hlsl"
#include "UnityPBSLighting.cginc"
#include "UnityMetaPass.cginc"

struct vertexPoints
{
	float4 vertex : POSITION;
	float2 uv : TEXCOORD0;
	float2 uv2 : TEXCOORD1;
	
};
struct pixelPoints
{
	float4 vertex : SV_POSITION;
	float2 uv : TEXCOORD0;
	float2 uv2 : TEXCOORD1;
};

pixelPoints VERTEXSHADER (vertexPoints VERTEXSPACE)
{
	pixelPoints PIXELSPACE;
	PIXELSPACE.vertex = UnityObjectToClipPos(VERTEXSPACE.vertex);
	PIXELSPACE.uv = VERTEXSPACE.uv;
	PIXELSPACE.uv2 = VERTEXSPACE.uv2;
	return PIXELSPACE;
}

#define Number _FloatNumber
#define NumberOne _FloatVariable

/////////////////////////////////////////////////////////////////////////////////////////////
// Default 
/////////////////////////////////////////////////////////////////////////////////////////////



static float k = 20.0;
static float field = 0.0;
static float2 coord;

float2 center ( float2 border , float2 offset , float2 vel ) {
    float2 c;
    if ( vel.x == 0.0 && vel.y == 0.0 ) {
        c = 0.0;
    } 
    else {
        c = offset + vel * TIME *1.5;
        c = fmod ( c , 2. - 4. * border );
        if ( c.x > 1. - border.x ) c.x = 2. - c.x - 2. * border.x;
        if ( c.x < border.x ) c.x = 2. * border.x - c.x;
        if ( c.y > 1. - border.y ) c.y = 2. - c.y - 2. * border.y;
        if ( c.y < border.y ) c.y = 2. * border.y - c.y;
    }
    return c;
}

void circle ( float r , float3 col , float2 offset , float2 vel ) {
    float2 pos = coord.xy;
    float aspect = 1.0;
    float2 c = center ( float2 ( r / aspect , r ) , offset , vel );
    c.x *= aspect;
    float d = distance ( pos , c );
    field += ( k * r ) / ( d*d );
}
    
float3 band ( float shade, float low, float high, float3 col1, float3 col2 ) {

    if ( (shade >= low) && (shade <= high) ) {
        float delta = (shade - low) / (high - low);
        float3 colDiff = col2 - col1;
        return col1 + (delta * colDiff);
    }
    else
        return float3(0.0,0.0,0.0);
}

float3 gradient ( float shade ) {
    float3 colour = float3( (sin(TIME/2.0)*0.25)+0.25,0.0,(cos(TIME/2.0)*0.25)+0.25);
    
    float2 mouseScaled = 1.0;
    float3 col1 = float3(mouseScaled.x, 0.0, 1.0-mouseScaled.x);
    float3 col2 = float3(1.0-mouseScaled.x, 0.0, mouseScaled.x);
    float3 col3 = float3(mouseScaled.y, 1.0-mouseScaled.y, mouseScaled.y);
    float3 col4 = float3((mouseScaled.x+mouseScaled.y)/2.0, (mouseScaled.x+mouseScaled.y)/2.0, 1.0 - (mouseScaled.x+mouseScaled.y)/2.0);
    float3 col5 = float3(mouseScaled.y, mouseScaled.y, mouseScaled.y);
    
    colour += band ( shade, 0.0, 0.3, colour, col1 );
    colour += band ( shade, 0.3, 0.6, col1, col2 );
    colour += band ( shade, 0.6, 0.8, col2, col3 );
    colour += band ( shade, 0.8, 0.9, col3, col4 );
    colour += band ( shade, 0.9, 1.0, col4, col5 );
    
    return colour;
}




//////////////////////////////////////////////////////////////////////////////////////////////
/// DEFAULT
//////////////////////////////////////////////////////////////////////////////////////////////

fixed4 FRAGMENTSHADER (pixelPoints PIXELSPACE) : SV_Target
{
	float2 coordinate = PIXELSPACE.uv;
	float2 coordinateSprite = PIXELSPACE.uv2;
	
	float2 coordinateScale = (PIXELSPACE.uv * 2.0) - 0.5 ;
	
	float2 coordinateShade = coordinateScale/(float2(2.0, 2.0));
	
	float2 coordinateFull = ceil(coordinateShade);
	float3 colBase  = 0.0;  
	float3 colTexture = float3(coordinateScale.x + coordinateScale.y, coordinateScale.y - coordinateScale.x, pow(coordinate.x,2.0f));

//////////////////////////////////////////////////////////////////////////////////////////////
///	DEFAULT
//////////////////////////////////////////////////////////////////////////////////////////////
	colBase = 0.0;
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

    coord = coordinate;
    
    circle ( .03 , float3 ( 0.7 , 0.2 , 0.8 ) , float2 ( .6, .6 ) , float2 ( .30 , .70 ) );
    circle ( .05 , float3 ( 0.7 , 0.9 , 0.6 ) , float2 ( .1, .1 ) , float2 ( .02 , .20 ) );
    circle ( .07 , float3 ( 0.3 , 0.4 , 0.1 ) , float2 ( .1, .1 ) , float2 ( .10 , .04 ) );
    circle ( .10 , float3 ( 0.2 , 0.5 , 0.1 ) , float2 ( .3, .3 ) , float2 ( .10 , .20 ) );
    circle ( .20 , float3 ( 0.1 , 0.3 , 0.7 ) , float2 ( .2, .2 ) , float2 ( .40 , .25 ) );
    circle ( .30 , float3 ( 0.9 , 0.4 , 0.2 ) , float2 ( .0, .0 ) , float2 ( .15 , .20 ) );
    circle ( .30 , float3 ( 0.0 , 0.0 , 0.0 ) , float2 ( .0, .0 ),  float2 ( 0.0 , 0.0 ) );
    
    float shade = min ( 1.0, max ( field/256.0, 0.0 ) );
    
    float4 fragColor = float4( gradient(shade), 1.0 );

///////////////////////↓↓↓↓↓↓↓↓↓// THIS IS THE LAST STEP ON THE PROCESS
///////////////////////↓↓↓↓↓↓↓↓↓// THIS IS THE LAST STEP ON THE PROCESS
float4 outputSmoothed = smoothstep(0.0, 1.0, fragColor);

float4 colBackground = outputSmoothed;

bool StickerSprite = (_OverlaySelection == 0)?true:false;

// colBackground = float4(uv, 0.0, 1.0);
// return colBackground;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////LINES OF CODE FOR THE SDFs STICKERS /////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
if(StickerSprite)
{
    if(_GlowFull == 1.0)
    {

		float2 coordUV = coordinate;    
        float dSign = PaintSticker(_StickerType, coordUV, _MotionState, _RangeSOne_One0, _RangeSOne_One1, _RangeSOne_One2, _RangeSOne_One3,
                                                                                    _RangeSTen_Ten0, _RangeSTen_Ten1, _RangeSTen_Ten2, _RangeSTen_Ten3); 
        float4 colorOutputTotal = ColorSign(dSign, colBackground, _BorderColor, 75.5, _BorderSizeTwo, _BorderBlurriness); 
    
    	if(colorOutputTotal.w * -1.0 < 0)
    	{

    		// GetEmission(PIXELSPACE)/3.0
        	return colorOutputTotal + float4( _ColorGlowHDR.xyz / 3.0, _AlphaColor/3.0);
    	}
		else 
		{
			return 0.0;
		}	
    }
    else
    {
		float2 coordUV = coordinate;    
    	float dSign = PaintSticker(_StickerType, coordUV, _MotionState, _RangeSOne_One0, _RangeSOne_One1, _RangeSOne_One2, _RangeSOne_One3,
    	_RangeSTen_Ten0, _RangeSTen_Ten1, _RangeSTen_Ten2, _RangeSTen_Ten3); 
    	float4 colorOutputTotal = ColorSign(dSign, float4(0.0, 0.0, 0.0, 0.0), _BorderColor, 75.5, _BorderSizeTwo, _BorderBlurriness); 
        if(colorOutputTotal.w * -1.0 < 0)
    	{
    	return colorOutputTotal + float4( _ColorGlowHDR.xyz / 3.0, _AlphaColor/3.0);
	    }
		else 
		{
    	float4 colorOutputTotal = ColorSign(dSign, colBackground, float4(0.0, 0.0, 0.0, 0.0), 0.0, 0.0, _BorderBlurriness); 
		return colorOutputTotal;
		}	
	}
 }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////LINES OF CODE FOR THE SDFs STICKERS /////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////LINES OF CODE FOR THE SPRITES ///////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
else
{
	if(_GlowFull == 1.0)
	{
		float4 colorOutputTotal = PaintSprite(coordinateSprite, colBackground, _TextureSprite, _OutlineColor,
		_InVariableTick, _InVariableRatioX, _InVariableRatioY, _OutlineSprite);

		if(colorOutputTotal.w * -1.0 < 0)
		{
			return colorOutputTotal + float4( _ColorGlowHDR.xyz, _AlphaColor);
		}
		return 0.0;

	}
	else
	{
		float4 colorOutputTotal = PaintSpriteGlow(coordinateSprite, colBackground, _TextureSprite, _OutlineColor,
		_InVariableTick, _InVariableRatioX, _InVariableRatioY, _OutlineSprite);

		if(colorOutputTotal.w * -1.0 < 0)
		{
			return colorOutputTotal ;
		}
	
		return 0.0;
	
	}
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////LINES OF CODE FOR THE SPRITES ///////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// float radio = 0.5;
// float2 pointValue = float2(0.0, 0.0);
// float paintPoint = float2(abs(cos(_Time.y)), abs(sin(_Time.y)));
// float lenghtRadio = length(uv - pointValue);
// if (lenghtRadio < radio)
// {
// return float4(1.0, 1.0, 1.0, 1.0) ;
// return 0.0;
// }
// else
// {
// return 0.0;
// }

}