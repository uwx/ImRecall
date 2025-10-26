# Org.OpenAPITools.Api.PeopleApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreatePerson**](PeopleApi.md#createperson) | **POST** /people |  |
| [**DeletePeople**](PeopleApi.md#deletepeople) | **DELETE** /people |  |
| [**DeletePerson**](PeopleApi.md#deleteperson) | **DELETE** /people/{id} |  |
| [**GetAllPeople**](PeopleApi.md#getallpeople) | **GET** /people |  |
| [**GetPerson**](PeopleApi.md#getperson) | **GET** /people/{id} |  |
| [**GetPersonStatistics**](PeopleApi.md#getpersonstatistics) | **GET** /people/{id}/statistics |  |
| [**GetPersonThumbnail**](PeopleApi.md#getpersonthumbnail) | **GET** /people/{id}/thumbnail |  |
| [**MergePerson**](PeopleApi.md#mergeperson) | **POST** /people/{id}/merge |  |
| [**ReassignFaces**](PeopleApi.md#reassignfaces) | **PUT** /people/{id}/reassign |  |
| [**UpdatePeople**](PeopleApi.md#updatepeople) | **PUT** /people |  |
| [**UpdatePerson**](PeopleApi.md#updateperson) | **PUT** /people/{id} |  |

<a id="createperson"></a>
# **CreatePerson**
> PersonResponseDto CreatePerson (PersonCreateDto personCreateDto)



This endpoint requires the `person.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **personCreateDto** | [**PersonCreateDto**](PersonCreateDto.md) |  |  |

### Return type

[**PersonResponseDto**](PersonResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deletepeople"></a>
# **DeletePeople**
> void DeletePeople (BulkIdsDto bulkIdsDto)



This endpoint requires the `person.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **bulkIdsDto** | [**BulkIdsDto**](BulkIdsDto.md) |  |  |

### Return type

void (empty response body)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deleteperson"></a>
# **DeletePerson**
> void DeletePerson (Guid id)



This endpoint requires the `person.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

void (empty response body)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getallpeople"></a>
# **GetAllPeople**
> PeopleResponseDto GetAllPeople (Guid closestAssetId = null, Guid closestPersonId = null, decimal page = null, decimal size = null, bool withHidden = null)



This endpoint requires the `person.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **closestAssetId** | **Guid** |  | [optional]  |
| **closestPersonId** | **Guid** |  | [optional]  |
| **page** | **decimal** | Page number for pagination | [optional] [default to 1M] |
| **size** | **decimal** | Number of items per page | [optional] [default to 500M] |
| **withHidden** | **bool** |  | [optional]  |

### Return type

[**PeopleResponseDto**](PeopleResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getperson"></a>
# **GetPerson**
> PersonResponseDto GetPerson (Guid id)



This endpoint requires the `person.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**PersonResponseDto**](PersonResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getpersonstatistics"></a>
# **GetPersonStatistics**
> PersonStatisticsResponseDto GetPersonStatistics (Guid id)



This endpoint requires the `person.statistics` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**PersonStatisticsResponseDto**](PersonStatisticsResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getpersonthumbnail"></a>
# **GetPersonThumbnail**
> System.IO.Stream GetPersonThumbnail (Guid id)



This endpoint requires the `person.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

**System.IO.Stream**

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="mergeperson"></a>
# **MergePerson**
> List&lt;BulkIdResponseDto&gt; MergePerson (Guid id, MergePersonDto mergePersonDto)



This endpoint requires the `person.merge` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **mergePersonDto** | [**MergePersonDto**](MergePersonDto.md) |  |  |

### Return type

[**List&lt;BulkIdResponseDto&gt;**](BulkIdResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="reassignfaces"></a>
# **ReassignFaces**
> List&lt;PersonResponseDto&gt; ReassignFaces (Guid id, AssetFaceUpdateDto assetFaceUpdateDto)



This endpoint requires the `person.reassign` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **assetFaceUpdateDto** | [**AssetFaceUpdateDto**](AssetFaceUpdateDto.md) |  |  |

### Return type

[**List&lt;PersonResponseDto&gt;**](PersonResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="updatepeople"></a>
# **UpdatePeople**
> List&lt;BulkIdResponseDto&gt; UpdatePeople (PeopleUpdateDto peopleUpdateDto)



This endpoint requires the `person.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **peopleUpdateDto** | [**PeopleUpdateDto**](PeopleUpdateDto.md) |  |  |

### Return type

[**List&lt;BulkIdResponseDto&gt;**](BulkIdResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="updateperson"></a>
# **UpdatePerson**
> PersonResponseDto UpdatePerson (Guid id, PersonUpdateDto personUpdateDto)



This endpoint requires the `person.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **personUpdateDto** | [**PersonUpdateDto**](PersonUpdateDto.md) |  |  |

### Return type

[**PersonResponseDto**](PersonResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

