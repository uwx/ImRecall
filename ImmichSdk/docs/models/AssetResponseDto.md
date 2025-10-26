# Org.OpenAPITools.Model.AssetResponseDto

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Checksum** | **string** | base64 encoded sha1 hash | 
**CreatedAt** | **DateTime** | The UTC timestamp when the asset was originally uploaded to Immich. | 
**DeviceAssetId** | **string** |  | 
**DeviceId** | **string** |  | 
**Duration** | **string** |  | 
**FileCreatedAt** | **DateTime** | The actual UTC timestamp when the file was created/captured, preserving timezone information. This is the authoritative timestamp for chronological sorting within timeline groups. Combined with timezone data, this can be used to determine the exact moment the photo was taken. | 
**FileModifiedAt** | **DateTime** | The UTC timestamp when the file was last modified on the filesystem. This reflects the last time the physical file was changed, which may be different from when the photo was originally taken. | 
**HasMetadata** | **bool** |  | 
**Id** | **string** |  | 
**IsArchived** | **bool** |  | 
**IsFavorite** | **bool** |  | 
**IsOffline** | **bool** |  | 
**IsTrashed** | **bool** |  | 
**LocalDateTime** | **DateTime** | The local date and time when the photo/video was taken, derived from EXIF metadata. This represents the photographer&#39;s local time regardless of timezone, stored as a timezone-agnostic timestamp. Used for timeline grouping by \&quot;local\&quot; days and months. | 
**OriginalFileName** | **string** |  | 
**OriginalPath** | **string** |  | 
**OwnerId** | **string** |  | 
**Type** | **AssetTypeEnum** |  | 
**UpdatedAt** | **DateTime** | The UTC timestamp when the asset record was last updated in the database. This is automatically maintained by the database and reflects when any field in the asset was last modified. | 
**Visibility** | **AssetVisibility** |  | 
**DuplicateId** | **string** |  | [optional] 
**ExifInfo** | [**ExifResponseDto**](ExifResponseDto.md) |  | [optional] 
**LibraryId** | **string** | This property was deprecated in v1.106.0 | [optional] 
**LivePhotoVideoId** | **string** |  | [optional] 
**OriginalMimeType** | **string** |  | [optional] 
**Owner** | [**UserResponseDto**](UserResponseDto.md) |  | [optional] 
**People** | [**List&lt;PersonWithFacesResponseDto&gt;**](PersonWithFacesResponseDto.md) |  | [optional] 
**Resized** | **bool** | This property was deprecated in v1.113.0 | [optional] 
**Stack** | [**AssetStackResponseDto**](AssetStackResponseDto.md) |  | [optional] 
**Tags** | [**List&lt;TagResponseDto&gt;**](TagResponseDto.md) |  | [optional] 
**Thumbhash** | **string** |  | 
**UnassignedFaces** | [**List&lt;AssetFaceWithoutPersonResponseDto&gt;**](AssetFaceWithoutPersonResponseDto.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

