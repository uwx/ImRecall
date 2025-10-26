# Org.OpenAPITools.Model.SharedLinkEditDto

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AllowDownload** | **bool** |  | [optional] 
**AllowUpload** | **bool** |  | [optional] 
**ChangeExpiryTime** | **bool** | Few clients cannot send null to set the expiryTime to never. Setting this flag and not sending expiryAt is considered as null instead. Clients that can send null values can ignore this. | [optional] 
**Description** | **string** |  | [optional] 
**ExpiresAt** | **DateTime** |  | [optional] 
**Password** | **string** |  | [optional] 
**ShowMetadata** | **bool** |  | [optional] 
**Slug** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

