﻿// <auto-generated />
using System;
using BlazingQuartz.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SqliteMigrations.Migrations
{
    [DbContext(typeof(BlazingQuartzDbContext))]
    [Migration("20220912031801_InitialSchema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("BlazingQuartz.Core.Data.Entities.ExecutionLog", b =>
                {
                    b.Property<long>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("log_id");

                    b.Property<long>("DateAddedUtc")
                        .HasColumnType("INTEGER")
                        .HasColumnName("date_added_utc");

                    b.Property<string>("ErrorMessage")
                        .HasMaxLength(8000)
                        .HasColumnType("TEXT")
                        .HasColumnName("error_message");

                    b.Property<long?>("FireTimeUtc")
                        .HasColumnType("INTEGER")
                        .HasColumnName("fire_time_utc");

                    b.Property<bool?>("IsException")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_exception");

                    b.Property<bool?>("IsSuccess")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_success");

                    b.Property<bool?>("IsVetoed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_vetoed");

                    b.Property<string>("JobGroup")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("job_group");

                    b.Property<string>("JobName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("job_name");

                    b.Property<TimeSpan?>("JobRunTime")
                        .HasColumnType("TEXT")
                        .HasColumnName("job_run_time");

                    b.Property<string>("LogType")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("log_type");

                    b.Property<string>("Result")
                        .HasMaxLength(8000)
                        .HasColumnType("TEXT")
                        .HasColumnName("result");

                    b.Property<int?>("RetryCount")
                        .HasColumnType("INTEGER")
                        .HasColumnName("retry_count");

                    b.Property<string>("ReturnCode")
                        .HasMaxLength(28)
                        .HasColumnType("TEXT")
                        .HasColumnName("return_code");

                    b.Property<string>("RunInstanceId")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("run_instance_id");

                    b.Property<long?>("ScheduleFireTimeUtc")
                        .HasColumnType("INTEGER")
                        .HasColumnName("schedule_fire_time_utc");

                    b.Property<string>("TriggerGroup")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("trigger_group");

                    b.Property<string>("TriggerName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("trigger_name");

                    b.HasKey("LogId")
                        .HasName("pk_bqz_execution_logs");

                    b.HasIndex("RunInstanceId")
                        .IsUnique()
                        .HasDatabaseName("ix_bqz_execution_logs_run_instance_id");

                    b.HasIndex("DateAddedUtc", "LogType")
                        .HasDatabaseName("ix_bqz_execution_logs_date_added_utc_log_type");

                    b.HasIndex("TriggerName", "TriggerGroup", "JobName", "JobGroup", "DateAddedUtc")
                        .HasDatabaseName("ix_bqz_execution_logs_trigger_name_trigger_group_job_name_job_group_date_added_utc");

                    b.ToTable("bqz_execution_logs", (string)null);
                });

            modelBuilder.Entity("BlazingQuartz.Core.Data.Entities.ExecutionLog", b =>
                {
                    b.OwnsOne("BlazingQuartz.Core.Data.Entities.ExecutionLogDetail", "ExecutionLogDetail", b1 =>
                        {
                            b1.Property<long>("LogId")
                                .HasColumnType("INTEGER")
                                .HasColumnName("log_id");

                            b1.Property<int?>("ErrorCode")
                                .HasColumnType("INTEGER")
                                .HasColumnName("error_code");

                            b1.Property<string>("ErrorHelpLink")
                                .HasMaxLength(1000)
                                .HasColumnType("TEXT")
                                .HasColumnName("error_help_link");

                            b1.Property<string>("ErrorStackTrace")
                                .HasColumnType("TEXT")
                                .HasColumnName("error_stack_trace");

                            b1.Property<string>("ExecutionDetails")
                                .HasColumnType("TEXT")
                                .HasColumnName("execution_details");

                            b1.HasKey("LogId")
                                .HasName("pk_bqz_execution_log_details");

                            b1.ToTable("bqz_execution_log_details", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("LogId")
                                .HasConstraintName("fk_bqz_execution_log_details_bqz_execution_logs_log_id");
                        });

                    b.Navigation("ExecutionLogDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
