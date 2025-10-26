# Org.OpenAPITools.Model.TimeBucketAssetResponseDto

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**City** | **List&lt;string&gt;** | Array of city names extracted from EXIF GPS data | 
**Country** | **List&lt;string&gt;** | Array of country names extracted from EXIF GPS data | 
**Duration** | **List&lt;string&gt;** | Array of video durations in HH:MM:SS format (null for images) | 
**FileCreatedAt** | **List&lt;string&gt;** | Array of file creation timestamps in UTC (ISO 8601 format, without timezone) | 
**Id** | **List&lt;string&gt;** | Array of asset IDs in the time bucket | 
**IsFavorite** | **List&lt;bool&gt;** | Array indicating whether each asset is favorited | 
**IsImage** | **List&lt;bool&gt;** | Array indicating whether each asset is an image (false for videos) | 
**IsTrashed** | **List&lt;bool&gt;** | Array indicating whether each asset is in the trash | 
**LivePhotoVideoId** | **List&lt;string&gt;** | Array of live photo video asset IDs (null for non-live photos) | 
**LocalOffsetHours** | **List&lt;decimal&gt;** | Array of UTC offset hours at the time each photo was taken. Positive values are east of UTC, negative values are west of UTC. Values may be fractional (e.g., 5.5 for +05:30, -9.75 for -09:45). Applying this offset to &#39;fileCreatedAt&#39; will give you the time the photo was taken from the photographer&#39;s perspective. | 
**OwnerId** | **List&lt;string&gt;** | Array of owner IDs for each asset | 
**ProjectionType** | **List&lt;string&gt;** | Array of projection types for 360° content (e.g., \&quot;EQUIRECTANGULAR\&quot;, \&quot;CUBEFACE\&quot;, \&quot;CYLINDRICAL\&quot;) | 
**Ratio** | **List&lt;decimal&gt;** | Array of aspect ratios (width/height) for each asset | 
**Thumbhash** | **List&lt;string&gt;** | Array of BlurHash strings for generating asset previews (base64 encoded) | 
**Visibility** | [**List&lt;AssetVisibility&gt;**](AssetVisibility.md) | Array of visibility statuses for each asset (e.g., ARCHIVE, TIMELINE, HIDDEN, LOCKED) | 
**Latitude** | **List&lt;decimal&gt;** | Array of latitude coordinates extracted from EXIF GPS data | [optional] 
**Longitude** | **List&lt;decimal&gt;** | Array of longitude coordinates extracted from EXIF GPS data | [optional] 
**Stack** | **List&lt;List&lt;string&gt;&gt;** | Array of stack information as [stackId, assetCount] tuples (null for non-stacked assets) | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

