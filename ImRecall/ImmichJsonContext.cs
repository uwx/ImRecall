using System.Text.Json;
using System.Text.Json.Serialization;
using Org.OpenAPITools.Model;

namespace ImRecall;

[JsonSourceGenerationOptions(JsonSerializerDefaults.General)]
[JsonSerializable(typeof(AlbumsAddAssetsResponseDto))]
[JsonSerializable(typeof(AlbumsResponse))]
[JsonSerializable(typeof(AlbumStatisticsResponseDto))]
[JsonSerializable(typeof(AlbumsUpdate))]
[JsonSerializable(typeof(AlbumUserAddDto))]
[JsonSerializable(typeof(AlbumUserCreateDto))]
[JsonSerializable(typeof(AlbumUserResponseDto))]
[JsonSerializable(typeof(AlbumUserRole))]
[JsonSerializable(typeof(AllJobStatusResponseDto))]
[JsonSerializable(typeof(APIKeyCreateDto))]
[JsonSerializable(typeof(APIKeyCreateResponseDto))]
[JsonSerializable(typeof(APIKeyResponseDto))]
[JsonSerializable(typeof(APIKeyUpdateDto))]
[JsonSerializable(typeof(AssetBulkDeleteDto))]
[JsonSerializable(typeof(AssetBulkUpdateDto))]
[JsonSerializable(typeof(AssetBulkUploadCheckDto))]
[JsonSerializable(typeof(AssetBulkUploadCheckItem))]
[JsonSerializable(typeof(AssetBulkUploadCheckResponseDto))]
[JsonSerializable(typeof(AssetBulkUploadCheckResult))]
[JsonSerializable(typeof(AssetDeltaSyncDto))]
[JsonSerializable(typeof(AssetDeltaSyncResponseDto))]
[JsonSerializable(typeof(AssetFaceCreateDto))]
[JsonSerializable(typeof(AssetFaceDeleteDto))]
[JsonSerializable(typeof(AssetFaceResponseDto))]
[JsonSerializable(typeof(AssetFaceUpdateDto))]
[JsonSerializable(typeof(AssetFaceUpdateItem))]
[JsonSerializable(typeof(AssetFaceWithoutPersonResponseDto))]
[JsonSerializable(typeof(AssetFullSyncDto))]
[JsonSerializable(typeof(AssetIdsDto))]
[JsonSerializable(typeof(AssetIdsResponseDto))]
[JsonSerializable(typeof(AssetJobName))]
[JsonSerializable(typeof(AssetJobsDto))]
[JsonSerializable(typeof(AssetMediaResponseDto))]
[JsonSerializable(typeof(AssetMediaSize))]
[JsonSerializable(typeof(AssetMediaStatus))]
[JsonSerializable(typeof(AssetMetadataKey))]
[JsonSerializable(typeof(AssetMetadataResponseDto))]
[JsonSerializable(typeof(AssetMetadataUpsertDto))]
[JsonSerializable(typeof(AssetMetadataUpsertItemDto))]
[JsonSerializable(typeof(AssetOrder))]
[JsonSerializable(typeof(AssetResponseDto))]
[JsonSerializable(typeof(AssetStackResponseDto))]
[JsonSerializable(typeof(AssetStatsResponseDto))]
[JsonSerializable(typeof(AssetTypeEnum))]
[JsonSerializable(typeof(AssetVisibility))]
[JsonSerializable(typeof(AudioCodec))]
[JsonSerializable(typeof(AuthStatusResponseDto))]
[JsonSerializable(typeof(AvatarUpdate))]
[JsonSerializable(typeof(BulkIdErrorReason))]
[JsonSerializable(typeof(BulkIdResponseDto))]
[JsonSerializable(typeof(BulkIdsDto))]
[JsonSerializable(typeof(CastResponse))]
[JsonSerializable(typeof(CastUpdate))]
[JsonSerializable(typeof(ChangePasswordDto))]
[JsonSerializable(typeof(CheckExistingAssetsDto))]
[JsonSerializable(typeof(CheckExistingAssetsResponseDto))]
[JsonSerializable(typeof(CLIPConfig))]
[JsonSerializable(typeof(Colorspace))]
[JsonSerializable(typeof(ContributorCountResponseDto))]
[JsonSerializable(typeof(CQMode))]
[JsonSerializable(typeof(CreateAlbumDto))]
[JsonSerializable(typeof(CreateLibraryDto))]
[JsonSerializable(typeof(CreateProfileImageResponseDto))]
[JsonSerializable(typeof(DatabaseBackupConfig))]
[JsonSerializable(typeof(DownloadArchiveInfo))]
[JsonSerializable(typeof(DownloadInfoDto))]
[JsonSerializable(typeof(DownloadResponse))]
[JsonSerializable(typeof(DownloadResponseDto))]
[JsonSerializable(typeof(DownloadUpdate))]
[JsonSerializable(typeof(DuplicateDetectionConfig))]
[JsonSerializable(typeof(DuplicateResponseDto))]
[JsonSerializable(typeof(EmailNotificationsResponse))]
[JsonSerializable(typeof(EmailNotificationsUpdate))]
[JsonSerializable(typeof(ExifResponseDto))]
[JsonSerializable(typeof(FaceDto))]
[JsonSerializable(typeof(FacialRecognitionConfig))]
[JsonSerializable(typeof(FoldersResponse))]
[JsonSerializable(typeof(FoldersUpdate))]
[JsonSerializable(typeof(ImageFormat))]
[JsonSerializable(typeof(JobCommand))]
[JsonSerializable(typeof(JobCommandDto))]
[JsonSerializable(typeof(JobCountsDto))]
[JsonSerializable(typeof(JobCreateDto))]
[JsonSerializable(typeof(JobName))]
[JsonSerializable(typeof(JobSettingsDto))]
[JsonSerializable(typeof(JobStatusDto))]
[JsonSerializable(typeof(LibraryResponseDto))]
[JsonSerializable(typeof(LibraryStatsResponseDto))]
[JsonSerializable(typeof(LicenseKeyDto))]
[JsonSerializable(typeof(LicenseResponseDto))]
[JsonSerializable(typeof(LoginCredentialDto))]
[JsonSerializable(typeof(LoginResponseDto))]
[JsonSerializable(typeof(LogLevel))]
[JsonSerializable(typeof(LogoutResponseDto))]
[JsonSerializable(typeof(MachineLearningAvailabilityChecksDto))]
[JsonSerializable(typeof(ManualJobName))]
[JsonSerializable(typeof(MapMarkerResponseDto))]
[JsonSerializable(typeof(MapReverseGeocodeResponseDto))]
[JsonSerializable(typeof(MemoriesResponse))]
[JsonSerializable(typeof(MemoriesUpdate))]
[JsonSerializable(typeof(MemoryCreateDto))]
[JsonSerializable(typeof(MemoryResponseDto))]
[JsonSerializable(typeof(MemoryStatisticsResponseDto))]
[JsonSerializable(typeof(MemoryType))]
[JsonSerializable(typeof(MemoryUpdateDto))]
[JsonSerializable(typeof(MergePersonDto))]
[JsonSerializable(typeof(MetadataSearchDto))]
[JsonSerializable(typeof(NotificationCreateDto))]
[JsonSerializable(typeof(NotificationDeleteAllDto))]
[JsonSerializable(typeof(NotificationDto))]
[JsonSerializable(typeof(NotificationLevel))]
[JsonSerializable(typeof(NotificationType))]
[JsonSerializable(typeof(NotificationUpdateAllDto))]
[JsonSerializable(typeof(NotificationUpdateDto))]
[JsonSerializable(typeof(OAuthAuthorizeResponseDto))]
[JsonSerializable(typeof(OAuthCallbackDto))]
[JsonSerializable(typeof(OAuthConfigDto))]
[JsonSerializable(typeof(OAuthTokenEndpointAuthMethod))]
[JsonSerializable(typeof(OnboardingDto))]
[JsonSerializable(typeof(OnboardingResponseDto))]
[JsonSerializable(typeof(OnThisDayDto))]
[JsonSerializable(typeof(PartnerCreateDto))]
[JsonSerializable(typeof(PartnerDirection))]
[JsonSerializable(typeof(PartnerResponseDto))]
[JsonSerializable(typeof(PartnerUpdateDto))]
[JsonSerializable(typeof(PeopleResponse))]
[JsonSerializable(typeof(PeopleResponseDto))]
[JsonSerializable(typeof(PeopleUpdate))]
[JsonSerializable(typeof(PeopleUpdateDto))]
[JsonSerializable(typeof(PeopleUpdateItem))]
[JsonSerializable(typeof(Permission))]
[JsonSerializable(typeof(PersonCreateDto))]
[JsonSerializable(typeof(PersonResponseDto))]
[JsonSerializable(typeof(PersonStatisticsResponseDto))]
[JsonSerializable(typeof(PersonUpdateDto))]
[JsonSerializable(typeof(PersonWithFacesResponseDto))]
[JsonSerializable(typeof(PinCodeChangeDto))]
[JsonSerializable(typeof(PinCodeResetDto))]
[JsonSerializable(typeof(PinCodeSetupDto))]
[JsonSerializable(typeof(PlacesResponseDto))]
[JsonSerializable(typeof(PurchaseResponse))]
[JsonSerializable(typeof(PurchaseUpdate))]
[JsonSerializable(typeof(QueueStatusDto))]
[JsonSerializable(typeof(RandomSearchDto))]
[JsonSerializable(typeof(RatingsResponse))]
[JsonSerializable(typeof(RatingsUpdate))]
[JsonSerializable(typeof(ReactionLevel))]
[JsonSerializable(typeof(ReactionType))]
[JsonSerializable(typeof(ReverseGeocodingStateResponseDto))]
[JsonSerializable(typeof(SearchAlbumResponseDto))]
[JsonSerializable(typeof(SearchAssetResponseDto))]
[JsonSerializable(typeof(SearchExploreItem))]
[JsonSerializable(typeof(SearchExploreResponseDto))]
[JsonSerializable(typeof(SearchFacetCountResponseDto))]
[JsonSerializable(typeof(SearchFacetResponseDto))]
[JsonSerializable(typeof(SearchResponseDto))]
[JsonSerializable(typeof(SearchStatisticsResponseDto))]
[JsonSerializable(typeof(SearchSuggestionType))]
[JsonSerializable(typeof(ServerAboutResponseDto))]
[JsonSerializable(typeof(ServerApkLinksDto))]
[JsonSerializable(typeof(ServerConfigDto))]
[JsonSerializable(typeof(ServerFeaturesDto))]
[JsonSerializable(typeof(ServerMediaTypesResponseDto))]
[JsonSerializable(typeof(ServerPingResponse))]
[JsonSerializable(typeof(ServerStatsResponseDto))]
[JsonSerializable(typeof(ServerStorageResponseDto))]
[JsonSerializable(typeof(ServerThemeDto))]
[JsonSerializable(typeof(ServerVersionHistoryResponseDto))]
[JsonSerializable(typeof(ServerVersionResponseDto))]
[JsonSerializable(typeof(SessionCreateDto))]
[JsonSerializable(typeof(SessionCreateResponseDto))]
[JsonSerializable(typeof(SessionResponseDto))]
[JsonSerializable(typeof(SessionUnlockDto))]
[JsonSerializable(typeof(SessionUpdateDto))]
[JsonSerializable(typeof(SharedLinkCreateDto))]
[JsonSerializable(typeof(SharedLinkEditDto))]
[JsonSerializable(typeof(SharedLinkResponseDto))]
[JsonSerializable(typeof(SharedLinksResponse))]
[JsonSerializable(typeof(SharedLinksUpdate))]
[JsonSerializable(typeof(SharedLinkType))]
[JsonSerializable(typeof(SignUpDto))]
[JsonSerializable(typeof(SmartSearchDto))]
[JsonSerializable(typeof(SourceType))]
[JsonSerializable(typeof(StackCreateDto))]
[JsonSerializable(typeof(StackResponseDto))]
[JsonSerializable(typeof(StackUpdateDto))]
[JsonSerializable(typeof(StatisticsSearchDto))]
[JsonSerializable(typeof(SyncAckDeleteDto))]
[JsonSerializable(typeof(SyncAckDto))]
[JsonSerializable(typeof(SyncAckSetDto))]
[JsonSerializable(typeof(SyncAlbumDeleteV1))]
[JsonSerializable(typeof(SyncAlbumToAssetDeleteV1))]
[JsonSerializable(typeof(SyncAlbumToAssetV1))]
[JsonSerializable(typeof(SyncAlbumUserDeleteV1))]
[JsonSerializable(typeof(SyncAlbumUserV1))]
[JsonSerializable(typeof(SyncAlbumV1))]
[JsonSerializable(typeof(SyncAssetDeleteV1))]
[JsonSerializable(typeof(SyncAssetExifV1))]
[JsonSerializable(typeof(SyncAssetFaceDeleteV1))]
[JsonSerializable(typeof(SyncAssetFaceV1))]
[JsonSerializable(typeof(SyncAssetMetadataDeleteV1))]
[JsonSerializable(typeof(SyncAssetMetadataV1))]
[JsonSerializable(typeof(SyncAssetV1))]
[JsonSerializable(typeof(SyncAuthUserV1))]
[JsonSerializable(typeof(SyncEntityType))]
[JsonSerializable(typeof(SyncMemoryAssetDeleteV1))]
[JsonSerializable(typeof(SyncMemoryAssetV1))]
[JsonSerializable(typeof(SyncMemoryDeleteV1))]
[JsonSerializable(typeof(SyncMemoryV1))]
[JsonSerializable(typeof(SyncPartnerDeleteV1))]
[JsonSerializable(typeof(SyncPartnerV1))]
[JsonSerializable(typeof(SyncPersonDeleteV1))]
[JsonSerializable(typeof(SyncPersonV1))]
[JsonSerializable(typeof(SyncRequestType))]
[JsonSerializable(typeof(SyncStackDeleteV1))]
[JsonSerializable(typeof(SyncStackV1))]
[JsonSerializable(typeof(SyncStreamDto))]
[JsonSerializable(typeof(SyncUserDeleteV1))]
[JsonSerializable(typeof(SyncUserMetadataDeleteV1))]
[JsonSerializable(typeof(SyncUserMetadataV1))]
[JsonSerializable(typeof(SyncUserV1))]
[JsonSerializable(typeof(SystemConfigBackupsDto))]
[JsonSerializable(typeof(SystemConfigDto))]
[JsonSerializable(typeof(SystemConfigFacesDto))]
[JsonSerializable(typeof(SystemConfigFFmpegDto))]
[JsonSerializable(typeof(SystemConfigGeneratedFullsizeImageDto))]
[JsonSerializable(typeof(SystemConfigGeneratedImageDto))]
[JsonSerializable(typeof(SystemConfigImageDto))]
[JsonSerializable(typeof(SystemConfigJobDto))]
[JsonSerializable(typeof(SystemConfigLibraryDto))]
[JsonSerializable(typeof(SystemConfigLibraryScanDto))]
[JsonSerializable(typeof(SystemConfigLibraryWatchDto))]
[JsonSerializable(typeof(SystemConfigLoggingDto))]
[JsonSerializable(typeof(SystemConfigMachineLearningDto))]
[JsonSerializable(typeof(SystemConfigMapDto))]
[JsonSerializable(typeof(SystemConfigMetadataDto))]
[JsonSerializable(typeof(SystemConfigNewVersionCheckDto))]
[JsonSerializable(typeof(SystemConfigNightlyTasksDto))]
[JsonSerializable(typeof(SystemConfigNotificationsDto))]
[JsonSerializable(typeof(SystemConfigOAuthDto))]
[JsonSerializable(typeof(SystemConfigPasswordLoginDto))]
[JsonSerializable(typeof(SystemConfigReverseGeocodingDto))]
[JsonSerializable(typeof(SystemConfigServerDto))]
[JsonSerializable(typeof(SystemConfigSmtpDto))]
[JsonSerializable(typeof(SystemConfigSmtpTransportDto))]
[JsonSerializable(typeof(SystemConfigStorageTemplateDto))]
[JsonSerializable(typeof(SystemConfigTemplateEmailsDto))]
[JsonSerializable(typeof(SystemConfigTemplatesDto))]
[JsonSerializable(typeof(SystemConfigTemplateStorageOptionDto))]
[JsonSerializable(typeof(SystemConfigThemeDto))]
[JsonSerializable(typeof(SystemConfigTrashDto))]
[JsonSerializable(typeof(SystemConfigUserDto))]
[JsonSerializable(typeof(TagBulkAssetsDto))]
[JsonSerializable(typeof(TagBulkAssetsResponseDto))]
[JsonSerializable(typeof(TagCreateDto))]
[JsonSerializable(typeof(TagResponseDto))]
[JsonSerializable(typeof(TagsResponse))]
[JsonSerializable(typeof(TagsUpdate))]
[JsonSerializable(typeof(TagUpdateDto))]
[JsonSerializable(typeof(TagUpsertDto))]
[JsonSerializable(typeof(TemplateDto))]
[JsonSerializable(typeof(TemplateResponseDto))]
[JsonSerializable(typeof(TestEmailResponseDto))]
[JsonSerializable(typeof(TimeBucketAssetResponseDto))]
[JsonSerializable(typeof(TimeBucketsResponseDto))]
[JsonSerializable(typeof(ToneMapping))]
[JsonSerializable(typeof(TranscodeHWAccel))]
[JsonSerializable(typeof(TranscodePolicy))]
[JsonSerializable(typeof(TrashResponseDto))]
[JsonSerializable(typeof(UpdateAlbumDto))]
[JsonSerializable(typeof(UpdateAlbumUserDto))]
[JsonSerializable(typeof(UpdateAssetDto))]
[JsonSerializable(typeof(UpdateLibraryDto))]
[JsonSerializable(typeof(UsageByUserDto))]
[JsonSerializable(typeof(UserAdminCreateDto))]
[JsonSerializable(typeof(UserAdminDeleteDto))]
[JsonSerializable(typeof(UserAdminResponseDto))]
[JsonSerializable(typeof(UserAdminUpdateDto))]
[JsonSerializable(typeof(UserAvatarColor))]
[JsonSerializable(typeof(UserLicense))]
[JsonSerializable(typeof(UserMetadataKey))]
[JsonSerializable(typeof(UserPreferencesResponseDto))]
[JsonSerializable(typeof(UserPreferencesUpdateDto))]
[JsonSerializable(typeof(UserResponseDto))]
[JsonSerializable(typeof(UserStatus))]
[JsonSerializable(typeof(UserUpdateMeDto))]
[JsonSerializable(typeof(ValidateAccessTokenResponseDto))]
[JsonSerializable(typeof(ValidateLibraryDto))]
[JsonSerializable(typeof(ValidateLibraryImportPathResponseDto))]
[JsonSerializable(typeof(ValidateLibraryResponseDto))]
[JsonSerializable(typeof(VersionCheckStateResponseDto))]
[JsonSerializable(typeof(VideoCodec))]
[JsonSerializable(typeof(VideoContainer))]
[JsonSerializable(typeof(ActivityCreateDto))]
[JsonSerializable(typeof(ActivityResponseDto))]
[JsonSerializable(typeof(ActivityStatisticsResponseDto))]
[JsonSerializable(typeof(AddUsersDto))]
[JsonSerializable(typeof(AdminOnboardingUpdateDto))]
[JsonSerializable(typeof(AlbumResponseDto))]
[JsonSerializable(typeof(AlbumsAddAssetsDto))]
[JsonSerializable(typeof(AlbumResponseDto[]))]
public partial class ImmichJsonContext : JsonSerializerContext
{
    public static ImmichJsonContext WithConverters { get; } = new(
        new JsonSerializerOptions(JsonSerializerDefaults.General)
        {
            Converters =
            {
                new AlbumsAddAssetsResponseDtoJsonConverter(),
                new AlbumsResponseJsonConverter(),
                new AlbumStatisticsResponseDtoJsonConverter(),
                new AlbumsUpdateJsonConverter(),
                new AlbumUserAddDtoJsonConverter(),
                new AlbumUserCreateDtoJsonConverter(),
                new AlbumUserResponseDtoJsonConverter(),
                new AlbumUserRoleJsonConverter(),
                new AllJobStatusResponseDtoJsonConverter(),
                new APIKeyCreateDtoJsonConverter(),
                new APIKeyCreateResponseDtoJsonConverter(),
                new APIKeyResponseDtoJsonConverter(),
                new APIKeyUpdateDtoJsonConverter(),
                new AssetBulkDeleteDtoJsonConverter(),
                new AssetBulkUpdateDtoJsonConverter(),
                new AssetBulkUploadCheckDtoJsonConverter(),
                new AssetBulkUploadCheckItemJsonConverter(),
                new AssetBulkUploadCheckResponseDtoJsonConverter(),
                new AssetBulkUploadCheckResultJsonConverter(),
                new AssetDeltaSyncDtoJsonConverter(),
                new AssetDeltaSyncResponseDtoJsonConverter(),
                new AssetFaceCreateDtoJsonConverter(),
                new AssetFaceDeleteDtoJsonConverter(),
                new AssetFaceResponseDtoJsonConverter(),
                new AssetFaceUpdateDtoJsonConverter(),
                new AssetFaceUpdateItemJsonConverter(),
                new AssetFaceWithoutPersonResponseDtoJsonConverter(),
                new AssetFullSyncDtoJsonConverter(),
                new AssetIdsDtoJsonConverter(),
                new AssetIdsResponseDtoJsonConverter(),
                new AssetJobNameJsonConverter(),
                new AssetJobsDtoJsonConverter(),
                new AssetMediaResponseDtoJsonConverter(),
                new AssetMediaSizeJsonConverter(),
                new AssetMediaStatusJsonConverter(),
                new AssetMetadataKeyJsonConverter(),
                new AssetMetadataResponseDtoJsonConverter(),
                new AssetMetadataUpsertDtoJsonConverter(),
                new AssetMetadataUpsertItemDtoJsonConverter(),
                new AssetOrderJsonConverter(),
                new AssetResponseDtoJsonConverter(),
                new AssetStackResponseDtoJsonConverter(),
                new AssetStatsResponseDtoJsonConverter(),
                new AssetTypeEnumJsonConverter(),
                new AssetVisibilityJsonConverter(),
                new AudioCodecJsonConverter(),
                new AuthStatusResponseDtoJsonConverter(),
                new AvatarUpdateJsonConverter(),
                new BulkIdErrorReasonJsonConverter(),
                new BulkIdResponseDtoJsonConverter(),
                new BulkIdsDtoJsonConverter(),
                new CastResponseJsonConverter(),
                new CastUpdateJsonConverter(),
                new ChangePasswordDtoJsonConverter(),
                new CheckExistingAssetsDtoJsonConverter(),
                new CheckExistingAssetsResponseDtoJsonConverter(),
                new CLIPConfigJsonConverter(),
                new ColorspaceJsonConverter(),
                new ContributorCountResponseDtoJsonConverter(),
                new CQModeJsonConverter(),
                new CreateAlbumDtoJsonConverter(),
                new CreateLibraryDtoJsonConverter(),
                new CreateProfileImageResponseDtoJsonConverter(),
                new DatabaseBackupConfigJsonConverter(),
                new DownloadArchiveInfoJsonConverter(),
                new DownloadInfoDtoJsonConverter(),
                new DownloadResponseJsonConverter(),
                new DownloadResponseDtoJsonConverter(),
                new DownloadUpdateJsonConverter(),
                new DuplicateDetectionConfigJsonConverter(),
                new DuplicateResponseDtoJsonConverter(),
                new EmailNotificationsResponseJsonConverter(),
                new EmailNotificationsUpdateJsonConverter(),
                new ExifResponseDtoJsonConverter(),
                new FaceDtoJsonConverter(),
                new FacialRecognitionConfigJsonConverter(),
                new FoldersResponseJsonConverter(),
                new FoldersUpdateJsonConverter(),
                new ImageFormatJsonConverter(),
                new JobCommandJsonConverter(),
                new JobCommandDtoJsonConverter(),
                new JobCountsDtoJsonConverter(),
                new JobCreateDtoJsonConverter(),
                new JobNameJsonConverter(),
                new JobSettingsDtoJsonConverter(),
                new JobStatusDtoJsonConverter(),
                new LibraryResponseDtoJsonConverter(),
                new LibraryStatsResponseDtoJsonConverter(),
                new LicenseKeyDtoJsonConverter(),
                new LicenseResponseDtoJsonConverter(),
                new LoginCredentialDtoJsonConverter(),
                new LoginResponseDtoJsonConverter(),
                new LogLevelJsonConverter(),
                new LogoutResponseDtoJsonConverter(),
                new MachineLearningAvailabilityChecksDtoJsonConverter(),
                new ManualJobNameJsonConverter(),
                new MapMarkerResponseDtoJsonConverter(),
                new MapReverseGeocodeResponseDtoJsonConverter(),
                new MemoriesResponseJsonConverter(),
                new MemoriesUpdateJsonConverter(),
                new MemoryCreateDtoJsonConverter(),
                new MemoryResponseDtoJsonConverter(),
                new MemoryStatisticsResponseDtoJsonConverter(),
                new MemoryTypeJsonConverter(),
                new MemoryUpdateDtoJsonConverter(),
                new MergePersonDtoJsonConverter(),
                new MetadataSearchDtoJsonConverter(),
                new NotificationCreateDtoJsonConverter(),
                new NotificationDeleteAllDtoJsonConverter(),
                new NotificationDtoJsonConverter(),
                new NotificationLevelJsonConverter(),
                new NotificationTypeJsonConverter(),
                new NotificationUpdateAllDtoJsonConverter(),
                new NotificationUpdateDtoJsonConverter(),
                new OAuthAuthorizeResponseDtoJsonConverter(),
                new OAuthCallbackDtoJsonConverter(),
                new OAuthConfigDtoJsonConverter(),
                new OAuthTokenEndpointAuthMethodJsonConverter(),
                new OnboardingDtoJsonConverter(),
                new OnboardingResponseDtoJsonConverter(),
                new OnThisDayDtoJsonConverter(),
                new PartnerCreateDtoJsonConverter(),
                new PartnerDirectionJsonConverter(),
                new PartnerResponseDtoJsonConverter(),
                new PartnerUpdateDtoJsonConverter(),
                new PeopleResponseJsonConverter(),
                new PeopleResponseDtoJsonConverter(),
                new PeopleUpdateJsonConverter(),
                new PeopleUpdateDtoJsonConverter(),
                new PeopleUpdateItemJsonConverter(),
                new PermissionJsonConverter(),
                new PersonCreateDtoJsonConverter(),
                new PersonResponseDtoJsonConverter(),
                new PersonStatisticsResponseDtoJsonConverter(),
                new PersonUpdateDtoJsonConverter(),
                new PersonWithFacesResponseDtoJsonConverter(),
                new PinCodeChangeDtoJsonConverter(),
                new PinCodeResetDtoJsonConverter(),
                new PinCodeSetupDtoJsonConverter(),
                new PlacesResponseDtoJsonConverter(),
                new PurchaseResponseJsonConverter(),
                new PurchaseUpdateJsonConverter(),
                new QueueStatusDtoJsonConverter(),
                new RandomSearchDtoJsonConverter(),
                new RatingsResponseJsonConverter(),
                new RatingsUpdateJsonConverter(),
                new ReactionLevelJsonConverter(),
                new ReactionTypeJsonConverter(),
                new ReverseGeocodingStateResponseDtoJsonConverter(),
                new SearchAlbumResponseDtoJsonConverter(),
                new SearchAssetResponseDtoJsonConverter(),
                new SearchExploreItemJsonConverter(),
                new SearchExploreResponseDtoJsonConverter(),
                new SearchFacetCountResponseDtoJsonConverter(),
                new SearchFacetResponseDtoJsonConverter(),
                new SearchResponseDtoJsonConverter(),
                new SearchStatisticsResponseDtoJsonConverter(),
                new SearchSuggestionTypeJsonConverter(),
                new ServerAboutResponseDtoJsonConverter(),
                new ServerApkLinksDtoJsonConverter(),
                new ServerConfigDtoJsonConverter(),
                new ServerFeaturesDtoJsonConverter(),
                new ServerMediaTypesResponseDtoJsonConverter(),
                new ServerPingResponseJsonConverter(),
                new ServerStatsResponseDtoJsonConverter(),
                new ServerStorageResponseDtoJsonConverter(),
                new ServerThemeDtoJsonConverter(),
                new ServerVersionHistoryResponseDtoJsonConverter(),
                new ServerVersionResponseDtoJsonConverter(),
                new SessionCreateDtoJsonConverter(),
                new SessionCreateResponseDtoJsonConverter(),
                new SessionResponseDtoJsonConverter(),
                new SessionUnlockDtoJsonConverter(),
                new SessionUpdateDtoJsonConverter(),
                new SharedLinkCreateDtoJsonConverter(),
                new SharedLinkEditDtoJsonConverter(),
                new SharedLinkResponseDtoJsonConverter(),
                new SharedLinksResponseJsonConverter(),
                new SharedLinksUpdateJsonConverter(),
                new SharedLinkTypeJsonConverter(),
                new SignUpDtoJsonConverter(),
                new SmartSearchDtoJsonConverter(),
                new SourceTypeJsonConverter(),
                new StackCreateDtoJsonConverter(),
                new StackResponseDtoJsonConverter(),
                new StackUpdateDtoJsonConverter(),
                new StatisticsSearchDtoJsonConverter(),
                new SyncAckDeleteDtoJsonConverter(),
                new SyncAckDtoJsonConverter(),
                new SyncAckSetDtoJsonConverter(),
                new SyncAlbumDeleteV1JsonConverter(),
                new SyncAlbumToAssetDeleteV1JsonConverter(),
                new SyncAlbumToAssetV1JsonConverter(),
                new SyncAlbumUserDeleteV1JsonConverter(),
                new SyncAlbumUserV1JsonConverter(),
                new SyncAlbumV1JsonConverter(),
                new SyncAssetDeleteV1JsonConverter(),
                new SyncAssetExifV1JsonConverter(),
                new SyncAssetFaceDeleteV1JsonConverter(),
                new SyncAssetFaceV1JsonConverter(),
                new SyncAssetMetadataDeleteV1JsonConverter(),
                new SyncAssetMetadataV1JsonConverter(),
                new SyncAssetV1JsonConverter(),
                new SyncAuthUserV1JsonConverter(),
                new SyncEntityTypeJsonConverter(),
                new SyncMemoryAssetDeleteV1JsonConverter(),
                new SyncMemoryAssetV1JsonConverter(),
                new SyncMemoryDeleteV1JsonConverter(),
                new SyncMemoryV1JsonConverter(),
                new SyncPartnerDeleteV1JsonConverter(),
                new SyncPartnerV1JsonConverter(),
                new SyncPersonDeleteV1JsonConverter(),
                new SyncPersonV1JsonConverter(),
                new SyncRequestTypeJsonConverter(),
                new SyncStackDeleteV1JsonConverter(),
                new SyncStackV1JsonConverter(),
                new SyncStreamDtoJsonConverter(),
                new SyncUserDeleteV1JsonConverter(),
                new SyncUserMetadataDeleteV1JsonConverter(),
                new SyncUserMetadataV1JsonConverter(),
                new SyncUserV1JsonConverter(),
                new SystemConfigBackupsDtoJsonConverter(),
                new SystemConfigDtoJsonConverter(),
                new SystemConfigFacesDtoJsonConverter(),
                new SystemConfigFFmpegDtoJsonConverter(),
                new SystemConfigGeneratedFullsizeImageDtoJsonConverter(),
                new SystemConfigGeneratedImageDtoJsonConverter(),
                new SystemConfigImageDtoJsonConverter(),
                new SystemConfigJobDtoJsonConverter(),
                new SystemConfigLibraryDtoJsonConverter(),
                new SystemConfigLibraryScanDtoJsonConverter(),
                new SystemConfigLibraryWatchDtoJsonConverter(),
                new SystemConfigLoggingDtoJsonConverter(),
                new SystemConfigMachineLearningDtoJsonConverter(),
                new SystemConfigMapDtoJsonConverter(),
                new SystemConfigMetadataDtoJsonConverter(),
                new SystemConfigNewVersionCheckDtoJsonConverter(),
                new SystemConfigNightlyTasksDtoJsonConverter(),
                new SystemConfigNotificationsDtoJsonConverter(),
                new SystemConfigOAuthDtoJsonConverter(),
                new SystemConfigPasswordLoginDtoJsonConverter(),
                new SystemConfigReverseGeocodingDtoJsonConverter(),
                new SystemConfigServerDtoJsonConverter(),
                new SystemConfigSmtpDtoJsonConverter(),
                new SystemConfigSmtpTransportDtoJsonConverter(),
                new SystemConfigStorageTemplateDtoJsonConverter(),
                new SystemConfigTemplateEmailsDtoJsonConverter(),
                new SystemConfigTemplatesDtoJsonConverter(),
                new SystemConfigTemplateStorageOptionDtoJsonConverter(),
                new SystemConfigThemeDtoJsonConverter(),
                new SystemConfigTrashDtoJsonConverter(),
                new SystemConfigUserDtoJsonConverter(),
                new TagBulkAssetsDtoJsonConverter(),
                new TagBulkAssetsResponseDtoJsonConverter(),
                new TagCreateDtoJsonConverter(),
                new TagResponseDtoJsonConverter(),
                new TagsResponseJsonConverter(),
                new TagsUpdateJsonConverter(),
                new TagUpdateDtoJsonConverter(),
                new TagUpsertDtoJsonConverter(),
                new TemplateDtoJsonConverter(),
                new TemplateResponseDtoJsonConverter(),
                new TestEmailResponseDtoJsonConverter(),
                new TimeBucketAssetResponseDtoJsonConverter(),
                new TimeBucketsResponseDtoJsonConverter(),
                new ToneMappingJsonConverter(),
                new TranscodeHWAccelJsonConverter(),
                new TranscodePolicyJsonConverter(),
                new TrashResponseDtoJsonConverter(),
                new UpdateAlbumDtoJsonConverter(),
                new UpdateAlbumUserDtoJsonConverter(),
                new UpdateAssetDtoJsonConverter(),
                new UpdateLibraryDtoJsonConverter(),
                new UsageByUserDtoJsonConverter(),
                new UserAdminCreateDtoJsonConverter(),
                new UserAdminDeleteDtoJsonConverter(),
                new UserAdminResponseDtoJsonConverter(),
                new UserAdminUpdateDtoJsonConverter(),
                new UserAvatarColorJsonConverter(),
                new UserLicenseJsonConverter(),
                new UserMetadataKeyJsonConverter(),
                new UserPreferencesResponseDtoJsonConverter(),
                new UserPreferencesUpdateDtoJsonConverter(),
                new UserResponseDtoJsonConverter(),
                new UserStatusJsonConverter(),
                new UserUpdateMeDtoJsonConverter(),
                new ValidateAccessTokenResponseDtoJsonConverter(),
                new ValidateLibraryDtoJsonConverter(),
                new ValidateLibraryImportPathResponseDtoJsonConverter(),
                new ValidateLibraryResponseDtoJsonConverter(),
                new VersionCheckStateResponseDtoJsonConverter(),
                new VideoCodecJsonConverter(),
                new VideoContainerJsonConverter(),
                new ActivityCreateDtoJsonConverter(),
                new ActivityResponseDtoJsonConverter(),
                new ActivityStatisticsResponseDtoJsonConverter(),
                new AddUsersDtoJsonConverter(),
                new AdminOnboardingUpdateDtoJsonConverter(),
                new AlbumResponseDtoJsonConverter(),
                new AlbumsAddAssetsDtoJsonConverter(),
                new UuidJsonConverter(),
            }
        });
}

public class UuidJsonConverter : JsonConverter<Guid>
{
    public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var guidString = reader.GetString();
        return guidString != null ? Guid.Parse(guidString) : Guid.Empty;
    }

    public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("D").ToLowerInvariant());
    }
}