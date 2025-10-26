# Org.OpenAPITools.Api.JobsApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateJob**](JobsApi.md#createjob) | **POST** /jobs |  |
| [**GetAllJobsStatus**](JobsApi.md#getalljobsstatus) | **GET** /jobs |  |
| [**SendJobCommand**](JobsApi.md#sendjobcommand) | **PUT** /jobs/{id} |  |

<a id="createjob"></a>
# **CreateJob**
> void CreateJob (JobCreateDto jobCreateDto)



This endpoint is an admin-only route, and requires the `job.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobCreateDto** | [**JobCreateDto**](JobCreateDto.md) |  |  |

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

<a id="getalljobsstatus"></a>
# **GetAllJobsStatus**
> AllJobStatusResponseDto GetAllJobsStatus ()



This endpoint is an admin-only route, and requires the `job.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**AllJobStatusResponseDto**](AllJobStatusResponseDto.md)

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

<a id="sendjobcommand"></a>
# **SendJobCommand**
> JobStatusDto SendJobCommand (JobName id, JobCommandDto jobCommandDto)



This endpoint is an admin-only route, and requires the `job.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **JobName** |  |  |
| **jobCommandDto** | [**JobCommandDto**](JobCommandDto.md) |  |  |

### Return type

[**JobStatusDto**](JobStatusDto.md)

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

