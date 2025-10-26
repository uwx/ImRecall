# Org.OpenAPITools.Api.PartnersApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreatePartner**](PartnersApi.md#createpartner) | **POST** /partners |  |
| [**CreatePartnerDeprecated**](PartnersApi.md#createpartnerdeprecated) | **POST** /partners/{id} |  |
| [**GetPartners**](PartnersApi.md#getpartners) | **GET** /partners |  |
| [**RemovePartner**](PartnersApi.md#removepartner) | **DELETE** /partners/{id} |  |
| [**UpdatePartner**](PartnersApi.md#updatepartner) | **PUT** /partners/{id} |  |

<a id="createpartner"></a>
# **CreatePartner**
> PartnerResponseDto CreatePartner (PartnerCreateDto partnerCreateDto)



This endpoint requires the `partner.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **partnerCreateDto** | [**PartnerCreateDto**](PartnerCreateDto.md) |  |  |

### Return type

[**PartnerResponseDto**](PartnerResponseDto.md)

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

<a id="createpartnerdeprecated"></a>
# **CreatePartnerDeprecated**
> PartnerResponseDto CreatePartnerDeprecated (Guid id)



This property was deprecated in v1.141.0. This endpoint requires the `partner.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**PartnerResponseDto**](PartnerResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getpartners"></a>
# **GetPartners**
> List&lt;PartnerResponseDto&gt; GetPartners (PartnerDirection direction)



This endpoint requires the `partner.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **direction** | **PartnerDirection** |  |  |

### Return type

[**List&lt;PartnerResponseDto&gt;**](PartnerResponseDto.md)

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

<a id="removepartner"></a>
# **RemovePartner**
> void RemovePartner (Guid id)



This endpoint requires the `partner.delete` permission.


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

<a id="updatepartner"></a>
# **UpdatePartner**
> PartnerResponseDto UpdatePartner (Guid id, PartnerUpdateDto partnerUpdateDto)



This endpoint requires the `partner.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **partnerUpdateDto** | [**PartnerUpdateDto**](PartnerUpdateDto.md) |  |  |

### Return type

[**PartnerResponseDto**](PartnerResponseDto.md)

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

