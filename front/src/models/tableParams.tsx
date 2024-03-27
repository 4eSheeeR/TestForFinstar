import { TablePaginationConfig, GetProp, TableProps } from "antd";

export interface TableParams {
    pagination?: TablePaginationConfig;
    sortField?: string;
    sortOrder?: string;
    filters?: Parameters<GetProp<TableProps, 'onChange'>>[1];
  };

 export const defaultTableParams = {
    pagination: {
      current: 1,
      pageSize: 10,
    },
  };