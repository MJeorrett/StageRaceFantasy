import { DataProvider, HttpError, fetchUtils } from "react-admin";
import rebuildHttpError from "./rebuildHttpError";
import config from "../../configuration";

const apiBaseUrl = config.apiBaseUrl;

const httpClient = fetchUtils.fetchJson;

const dataProvider: DataProvider = {
  getList: async (resource, params) => {
    const { page, perPage } = params.pagination;
    const query = {
      pageIndex: page - 1,
      pageSize: perPage,
    };

    const queryParams = fetchUtils.queryParameters(query);
    const url = `${apiBaseUrl}/${resource}?${queryParams}`;

    const { json } = await httpClient(url);

    return {
      data: json.content.items,
      total: json.content.totalCount,
    };
  },
  getOne: async (resource, params) => {
    const url = `${apiBaseUrl}/${resource}/${params.id}`;

    const { json } = await httpClient(url);

    return {
      data: json.content,
    };
  },
  getMany: async (resource) => {
    const query = {
      pageIndex: 1,
      pageSize: 1000,
    };

    const queryParams = fetchUtils.queryParameters(query);
    const url = `${apiBaseUrl}/${resource}?${queryParams}`;

    const { json } = await httpClient(url);

    return {
      data: json.content.items,
    };
  },
  getManyReference: async () => {
    throw new Error("getManyReference not implemented");
  },
  create: async (resource, params) => {
    try {
      const url = `${apiBaseUrl}/${resource}`;

      const { json } = await httpClient(url, {
        method: "POST",
        body: JSON.stringify(params.data),
      });

      return { data: { ...params.data, id: json.content } as never };
    } catch (error: unknown) {
      if (error instanceof HttpError) {
        throw rebuildHttpError(error);
      } else {
        throw error;
      }
    }
  },
  update: async (resource, params) => {
    try {
      const url = `${apiBaseUrl}/${resource}/${params.id}`;

      await httpClient(url, {
        method: "PUT",
        body: JSON.stringify(params.data),
      });

      return { data: params.data as never };
    } catch (error: unknown) {
      if (error instanceof HttpError) {
        throw rebuildHttpError(error);
      } else {
        throw error;
      }
    }
  },
  updateMany: async () => {
    throw new Error("updateMany not implemented");
  },
  delete: async () => {
    throw new Error("delete not implemented");
  },
  deleteMany: async () => {
    throw new Error("deleteMany not implemented");
  },
};

export default dataProvider;
